using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using FlightJournal.Web.Translations;
using System.Linq;

namespace FlightJournal.Web.Models
{
    public class Plane
    {
        public Plane()
        {
            CreatedTimestamp = DateTime.Now;
            LastUpdatedTimestamp = DateTime.Now;
        }
        public int PlaneId { get; set; }
        [Required]
        [LocalizedDisplayName("Aircraft Registration")]
        public string Registration { get; set; }
        [Required]
        [LocalizedDisplayName("Competition Number")]
        public string CompetitionId { get; set; }

        /// <summary>
        /// Overrides registration and competition (Must be unique) for dropdown lists
        /// </summary>
        [LocalizedDisplayName("Shortname")]
        public string ShortName { get; set; }

        [Required]
        [LocalizedDisplayName("Aircraft Type")]
        public string Type { get; set; }
        [LocalizedDisplayName("Aircraft Model")]
        public string Model { get; set; }
        [LocalizedDisplayName("Aircraft Class")]
        public string Class { get; set; }

        [LocalizedDisplayName("Aircraft Owner")]
        public string Owner { get; set; }
        [LocalizedDisplayName("Note")]
        public string Note { get; set; }
        
        [Required, Range(1,2)]
        [LocalizedDisplayName("Seats")]
        public int Seats { get; set; }
        [Required, Range(0, 1)]
        [LocalizedDisplayName("Engines")]
        public int Engines { get; set; }

        [LocalizedDisplayName("Exit date")]
        public DateTime? ExitDate { get; set; }

        [LocalizedDisplayName("Default Take-off method")]
        public int? StartTypeId { get; set; }

        [LocalizedDisplayName("Created")]
        public DateTime CreatedTimestamp { get; set; }
        [LocalizedDisplayName("Created by")]
        public string CreatedBy { get; set; }
        [LocalizedDisplayName("Last updated")]
        public DateTime LastUpdatedTimestamp { get; set; }
        [LocalizedDisplayName("Last updated by")]
        public string LastUpdatedBy { get; set; }

        [XmlIgnore]
        public string RenderName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.ShortName))
                {
                    return this.ShortName;
                }
                return string.Format("{0} ({1})", this.CompetitionId, this.Registration);
            }
        }

        [XmlIgnore]
        public virtual StartType DefaultStartType { get; set; }

        [XmlIgnore]
        public virtual ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return this.RenderName;
        }

        [XmlIgnore]
        public static Plane Unknown
        {
            get
            {
                using (var context = new FlightContext())
                {
                    var unknown = context.Planes.SingleOrDefault(p => p.PlaneId == -1);
                    if (unknown != null)
                        return unknown;

                    // Add missing Unknown Pilot (System pilot)
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Planes] ON");
                    unknown = new Plane() {PlaneId = -1, Registration = "???", CompetitionId = "??", Seats = 1 , Type = "???", Class = "???", CreatedBy = "System", CreatedTimestamp = DateTime.Now };
                    context.Planes.Add(unknown);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Planes] OFF");

                    return unknown;
                }
            }
        }
    }
}
