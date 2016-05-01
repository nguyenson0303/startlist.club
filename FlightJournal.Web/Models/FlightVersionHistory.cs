﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace FlightJournal.Web.Models
{
    public class FlightVersionHistory
    {
        public FlightVersionHistory()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightVersionHistory"/> class.
        /// </summary>
        /// <param name="flight">
        /// The flight.
        /// </param>
        /// <param name="entityState">
        /// The entity state.
        /// </param>
        public FlightVersionHistory(Flight f, EntityState entityState)
        {
            this.State = entityState.ToString();

            this.FlightId = f.FlightId;
            this.Created = DateTime.Now;
            this.Deleted = f.Deleted;
            this.LastUpdated = f.LastUpdated;
            this.LastUpdatedBy = f.LastUpdatedBy;
            this.Description = f.Description;

            this.Date = f.Date;
            this.Departure = f.Departure;
            this.Landing = f.Landing;
            this.LandingCount = f.LandingCount;
            this.PlaneId = f.PlaneId;
            this.PilotId = f.PilotId;
            this.PilotBackseatId = f.PilotBackseatId;
            this.BetalerId = f.BetalerId;
            this.StartTypeId = f.StartTypeId;
            this.StartedFromId = f.StartedFromId;
            this.LandedOnId = f.LandedOnId;
            this.TachoDeparture = f.TachoDeparture;
            this.TachoLanding = f.TachoLanding;

            this.OGNFlightLogId = f.OGNFlightLogId;
        }

        [Key]
        [Column(Order = 0)]
        public Guid FlightId { get; set; }
        [Key]
        [Column(Order = 1)]
        public DateTime Created { get; set; }
        /// <summary>
        /// Allows flight to be linked to OGNFlightLog entry
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string OGNFlightLogId { get; set; }
        
        public string State { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime? Departure { get; set; }
        [DataType(DataType.Time)]
        public DateTime? Landing { get; set; }
        [Required]
        public int LandingCount { get; set; }
        [Required]
        public int PlaneId { get; set; }
        public virtual Plane Plane { get; set; }
        public int PilotId { get; set; }
        public virtual Pilot Pilot { get; set; }
        public int? PilotBackseatId { get; set; }
        public virtual Pilot PilotBackseat { get; set; }
        public int StartTypeId { get; set; }
        public StartType StartType { get; set; }
        public int BetalerId { get; set; }
        public virtual Pilot Betaler { get; set; }
        public int StartedFromId { get; set; }
        [ForeignKey("StartedFromId")]
        public virtual Location StartedFrom { get; set; }
        public int? LandedOnId { get; set; }
        [ForeignKey("LandedOnId")]
        public virtual Location LandedOn { get; set; }
        public double? TachoDeparture { get; set; }
        public double? TachoLanding { get; set; }

        public string Description { get; set; }

        public DateTime? Deleted { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}