using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightJournal.Web.Controllers;
using FlightJournal.Web.Models;

namespace FlightJournal.Tests.Controllers
{
    [TestClass()]
    public class OpenGliderNetworkControllerTests
    {
        [TestMethod()]
        public void SynchronizeTest()
        {
            var icao = "EKKS";
            var date = new DateTime(2016,4,10);

            var ogn = OpenGliderNetworkController.GetFlights(icao, date);
            Assert.IsTrue(ogn.Count > 0);

            using (var context = new FlightContext())
            {
                var location = context.Locations.SingleOrDefault(l => l.ICAO == icao && l.RegisteredOgnFlightLogAirfield);
                Assert.IsNotNull(location);

                foreach (var flight in context.Flights.Where(s =>
                    (s.Date == date) &&
                    (s.LandedOn.LocationId == location.LocationId
                     || s.StartedFrom.LocationId == location.LocationId)))
                {
                    context.Flights.Remove(flight);    
                }
                context.SaveChanges();

                OpenGliderNetworkController.Synchronize(icao, date);

                var syncedFlights = context.Flights.Where(s =>
                    (s.Date == date) &&
                    (s.LandedOn.LocationId == location.LocationId
                     || s.StartedFrom.LocationId == location.LocationId));


                Assert.IsTrue(ogn.Count == syncedFlights.Count());
            }
        }
    }
}