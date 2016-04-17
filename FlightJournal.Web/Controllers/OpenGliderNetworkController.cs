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
                    BackgroundJob.Schedule(() => Synchronize(icao, DateTime.Today.AddDays(-1)), TimeSpan.FromMinutes(5));
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
                    // 
                }
                // TODO: Fetch flights from both OGN and Database and synchronize any differences. 
                // TODO: Create map from OGN to Flight so links can be managed.
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