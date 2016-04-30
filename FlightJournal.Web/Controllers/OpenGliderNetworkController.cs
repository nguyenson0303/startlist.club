using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightJournal.Web.Models;
using Hangfire;

namespace FlightJournal.Web.Controllers
{
    public class OpenGliderNetworkController : Controller
    {
        /// <summary>
        /// Synchronze Flight Log for yesterday on all airfields that have a location registered on OGN as a FlightLog Airfield 
        /// </summary>
        /// <remarks>Initialized by Hangfire as a recurring daily CRON job at 0 hour</remarks>
        public static void Synchronize()
        {
            using (var context = new FlightContext())
            {
                foreach (var icao in context.Clubs.Where(c=>c.Location.RegisteredOgnFlightLogAirfield).Select(x=>x.Location.ICAO))
                {
                    // Insert a little latency on each request for controlling load on open glider network
#if DEBUG
                    BackgroundJob.Schedule(() => Synchronize(icao, DateTime.Today.AddDays(-1)), TimeSpan.FromSeconds(30));
#else
                    BackgroundJob.Schedule(() => Synchronize(icao, DateTime.Today.AddDays(-1)), TimeSpan.FromMinutes(5));
#endif

                }
            }
        }

        public static void Synchronize(string icao, DateTime date)
        {
            using (var context = new FlightContext())
            {
                var location = context.Locations.SingleOrDefault(l => l.ICAO == icao && l.RegisteredOgnFlightLogAirfield);
                if (location == null)
                    return;

                var flights = context.Flights.Where(s =>
                                    (s.Date == date) && 
                                    (s.LandedOn.LocationId == location.LocationId 
                                            || s.StartedFrom.LocationId == location.LocationId))
                    .Include("Plane").Include("StartedFrom").Include("LandedOn").Include("Pilot").Include("PilotBackseat").Include("Betaler").Include("StartType")
                    .OrderByDescending(s => s.Date).ThenByDescending(s => s.Departure ?? DateTime.Now);

                var ognFlights = GetFlights(icao, date);

                foreach (var ognFlight in ognFlights)
                {
                    if (!ognFlight.takeoff.HasValue) continue;
                    if (flights.Any(f => f.OGNFlightLogId == ognFlight.ID && f.Landing != null)) continue;

                    // Flight has been created in earlier run and we only need to register the landing time if available and if not allready set. 
                    if (flights.Any(f => f.OGNFlightLogId == ognFlight.ID))
                    {
                        // have we created the flight and added an ogn flight log id ?
                        var flight = flights.SingleOrDefault(f => f.OGNFlightLogId == ognFlight.ID);
                        // have we registered the landing
                        if (flight == null) continue;
                        if (flight.Landing != null) continue;
                        if (!ognFlight.glider_landing.HasValue) continue;

                        flight.Landing = ognFlight.glider_landing.Value.DateTime;
                        if (flight.LandedOn == null) flight.LandedOn = location;

                        context.SaveChanges();
                        continue;
                    }

                    // register to any flights lined up with no set departure time
                        // having '-' in the plane name means the flight is on a registered plane, map to the registered aircraft
                        if (ognFlight.plane.Contains("-"))
                        {
                            // are there plane registrations, not bound to a ognflight, without a departure time
                            if (flights.Any(f => string.IsNullOrWhiteSpace(f.OGNFlightLogId) && !f.Departure.HasValue && String.Equals(f.Plane.Registration, ognFlight.plane, StringComparison.CurrentCultureIgnoreCase)))
                            {
                                var flight = flights.FirstOrDefault(f=>string.IsNullOrWhiteSpace(f.OGNFlightLogId) && !f.Departure.HasValue && String.Equals(f.Plane.Registration, ognFlight.plane, StringComparison.CurrentCultureIgnoreCase));
                                if (flight == null) continue;
                                flight.OGNFlightLogId = ognFlight.ID;
                                flight.Departure = ognFlight.takeoff.Value.DateTime;

                                if (ognFlight.glider_landing.HasValue && flight.Landing == null)
                                {
                                    flight.Landing = ognFlight.glider_landing.Value.DateTime;
                                }

                                context.SaveChanges();
                                continue;
                            }
                        }
                        else if (!ognFlight.plane.Contains("-"))
                        {
                            // are there registrations not bound to a ognflight, without a departure time
                            if (flights.Any(f => string.IsNullOrWhiteSpace(f.OGNFlightLogId) && !f.Departure.HasValue))
                            {
                                var flight = flights.FirstOrDefault(f => string.IsNullOrWhiteSpace(f.OGNFlightLogId) && !f.Departure.HasValue);
                                if (flight == null) continue;

                                flight.OGNFlightLogId = ognFlight.ID;
                                flight.Departure = ognFlight.takeoff.Value.DateTime;

                                if (ognFlight.glider_landing.HasValue && flight.Landing == null)
                                {
                                    flight.Landing = ognFlight.glider_landing.Value.DateTime;
                                }

                                context.SaveChanges();
                                continue;
                            }
                        }
                    
                    // if we are still here, we are a flight that is not registered and not lined up for flight
                    var newflight = new Flight()
                    {
                        OGNFlightLogId = ognFlight.ID,
                        Departure = ognFlight.takeoff.Value.DateTime,
                        StartedFrom = location
                    };

                    if (ognFlight.glider_landing.HasValue)
                    {
                        newflight.Landing = ognFlight.glider_landing.Value.DateTime;
                        newflight.LandedOn = location;
                    }

                    context.Flights.Add(newflight);
                    context.SaveChanges();
                    continue;
                }
            }
        }

        /// <summary>
        /// requests for dates prior to today are only done once and are stored locally.
        /// requests for todays date are live but have a cache of 20 minutes for keeping preasure off glidernet.
        /// </summary>
        /// <param name="icao">Airport ICAO</param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<OGN.FlightLog.Client.Models.Flight> GetFlights(string icao, DateTime date)
        {
            // invalidate requests for dates in the future. 
            if (date > DateTime.Today)
                return null;

            var cacheKey = icao + date.ToShortDateString();

            if (System.Web.HttpContext.Current?.Cache[cacheKey] != null)
                return System.Web.HttpContext.Current.Cache[cacheKey] as List<OGN.FlightLog.Client.Models.Flight>;

            // if request is for today the request is live to http://live.glidernet.org/flightlog/index.php?a=EKSL&s=QFE&u=M&z=0&p=&t=0&d=28032016 in json and parsed (for not overloading glidernet we cache the requests at least 20 min)
            // if request is for an older date the request is done once and is stored in local database storage.
            var ognFlights = OGN.FlightLog.Client.Client.GetFlights(new OGN.FlightLog.Client.Client.Options(icao, date));

            // TODO: Validate datetime timezone information relative to airport location... and to summer and winter time.

            // Add to cache and add with a fixed expiration. 
            System.Web.HttpContext.Current?.Cache.Add(cacheKey, ognFlights, null, DateTime.Now.AddMinutes(20), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);

            return ognFlights;
        }

        #region Wrapped into https://github.com/janhebnes/OGN.FlightLog.Client

        //http://live.glidernet.org/flightlog/index.php?a=EHDL&s=QFE&u=M&z=2&p=&d=30052015&j
        //http://stackoverflow.com/questions/32401704/appending-json-data-to-listview-c-sharp

        //        WebClient client = new WebClient();
        //        string json = client.DownloadString("http://live.glidernet.org/flightlog/index.php?a=EHDL&s=QFE&u=M&z=2&p=&d=30052015&j");

        //        JObject data = JObject.Parse(json);

        //        // create an array of ListViewItems from the JSON
        //        var items = data["flights"]
        //            .Children<JObject>()
        //            .Select(jo => new ListViewItem(new string[] 
        //{
        //    (string)jo["glider"],
        //    (string)jo["takeoff"],
        //    (string)jo["glider_landing"],
        //    (string)jo["glider_time"]
        //}))
        //            .ToArray();

        #endregion
    }
}