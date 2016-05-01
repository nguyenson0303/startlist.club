using System;
using System.Web.UI.WebControls;
using FlightJournal.Web.Translations;
using Microsoft.Ajax.Utilities;
using System.Linq;
using System.Xml.Serialization;

namespace FlightJournal.Web.Models
{
    public class Location
    {
        public Location()
        {
            CreatedTimestamp = DateTime.Now;
            LastUpdatedTimestamp = DateTime.Now;
        }
        public int LocationId { get; set; }
        [LocalizedDisplayName("Location Name")]
        public string Name { get; set; }
        [LocalizedDisplayName("ICAO")]
        public string ICAO { get; set; }
        [LocalizedDisplayName("Registered OGN FlightLog Airfield")]
        public bool RegisteredOgnFlightLogAirfield { get; set; }
        [LocalizedDisplayName("Country")]
        public string Country { get; set; } // ISO Alpha-2 code based on https://www.iso.org/obp/ui/#search
        [LocalizedDisplayName("Created")]
        public DateTime CreatedTimestamp { get; set; }
        [LocalizedDisplayName("Created by")]
        public string CreatedBy { get; set; }
        [LocalizedDisplayName("Last updated")]
        public DateTime LastUpdatedTimestamp { get; set; }
        [LocalizedDisplayName("Last updated by")]
        public string LastUpdatedBy { get; set; }

        public override string ToString()
        {
            return ToString(string.Empty);
        }
        /// <summary>
        /// Current country is used to change the formatting so local country is not shown .
        /// </summary>
        /// <param name="country">remember to convert to .ToUpperInvariant()</param>
        /// <returns></returns>
        public string ToString(string country)
        {
            // Shorten the string if current country
            if (!country.IsNullOrWhiteSpace() && country == Country && !ICAO.IsNullOrWhiteSpace())
                return this.Name + " " + ICAO + "";

            // Matching the format used by the OLC http://www.onlinecontest.org/ with ICAO instead of region
            if (!ICAO.IsNullOrWhiteSpace() && !Country.IsNullOrWhiteSpace())
                return this.Name + " " + ICAO + " (" + Country + ")";

            if (!Country.IsNullOrWhiteSpace())
                return this.Name + " (" + Country + ")";

            return Name;
        }


        [XmlIgnore]
        public static Location Missing
        {
            get
            {
                using (var context = new FlightContext())
                {
                    var missing = context.Locations.SingleOrDefault(p => p.LocationId == -2);
                    if (missing != null)
                        return missing;

                    // Add missing missing Club for Unknown Pilot (System pilot)
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Locations] ON");
                    missing = new Location() {LocationId = -2, Name = "???", CreatedBy = "System", CreatedTimestamp = DateTime.Now };
                    context.Locations.Add(missing);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Locations] OFF");

                    return missing;
                }
            }
        }
    }
}
