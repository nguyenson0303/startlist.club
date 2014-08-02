using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using FlightJournal.Web.Controllers;

namespace FlightJournal.Web.Models
{
    public class FlightContext : DbContext
    {
        public FlightContext() : base("FlightJournal")
        {
#if DEBUG
            Database.SetInitializer<FlightContext>(new FlightContextInitializer());
#endif
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightVersionHistory> FlightVersions { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<PilotStatusType> PilotStatusTypes { get; set; }
        public DbSet<StartType> StartTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PilotLogEntry> PilotLogEntries { get; set; }

        /// <summary>
        /// Throw Validation Errors from the Entity as actual Exceptions
        /// </summary>
        public void ThrowValidationErrors()
        {
            string errors = string.Empty;
            this.GetValidationErrors().ToList().ForEach(b => b.ValidationErrors.ToList().ForEach(c => errors = c.PropertyName + ": " + c.ErrorMessage));
            if (!string.IsNullOrEmpty(errors))
            {
                throw new Exception(errors);
            }
        }

        /// <summary>
        /// On Save we monitor if Validation errors are present and we Save flight information history automatically
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            this.ThrowValidationErrors();

            this.ChangeTracker.Entries<Flight>().Where(f => (f.State == EntityState.Added) || (f.State == EntityState.Deleted) || (f.State == EntityState.Modified))
                                    .ToList<DbEntityEntry<Flight>>()
                                    .ForEach((c => this.FlightVersions.Add(new FlightVersionHistory((Flight)c.Entity, c.State))));

            return base.SaveChanges();
        }

        /// <summary>
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                        .HasRequired(m => m.Pilot)
                        .WithMany(t => t.Flights)
                        .HasForeignKey(m => m.PilotId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                        .HasOptional(m => m.PilotBackseat)
                        .WithMany(t => t.Flights_Backseat)
                        .HasForeignKey(m => m.PilotBackseatId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                        .HasRequired(m => m.Betaler)
                        .WithMany(t => t.Flights_Betaler)
                        .HasForeignKey(m => m.BetalerId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<FlightVersionHistory>()
                .ToTable("FlightVersionHistory");

            modelBuilder.Entity<FlightVersionHistory>()
                        .HasRequired(m => m.Pilot)
                        .WithMany(t => t.FlightHistory_Pilots)
                        .HasForeignKey(m => m.PilotId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<FlightVersionHistory>()
                        .HasOptional(m => m.PilotBackseat)
                        .WithMany(t => t.FlightHistory_PilotBackseats)
                        .HasForeignKey(m => m.PilotBackseatId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<FlightVersionHistory>()
                        .HasRequired(m => m.Betaler)
                        .WithMany(t => t.FlightHistory_Betalers)
                        .HasForeignKey(m => m.BetalerId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<PilotLogEntry>()
                        .HasRequired(i => i.Pilot)
                        .WithMany()
                        .WillCascadeOnDelete(true);
            
            modelBuilder.Entity<PilotLogEntry>()
                        .HasRequired(i => i.Flight)
                        .WithMany()
                        .WillCascadeOnDelete(false);

        }

        
#if DEBUG
        /// HACK: Enabled only when working on database structure on the solution in development otherwise it might remove the database data 
        public class FlightContextInitializer : CreateDatabaseIfNotExists<FlightContext>
        {
            protected override void Seed(FlightContext context)
            {
                //InitializeDemoFlightsForEF(context);
                InitializeVGC2014ForEF(context);

                base.Seed(context);
            }

            public static void InitializeVGC2014ForEF(FlightContext context)
            {
                // StartType
                var start = new StartType() {Name = "Spilstart", ShortName = "S"};
                context.StartTypes.Add(start);
                context.StartTypes.Add(new StartType() {Name = "Flyslæb", ShortName = "F"});
                context.StartTypes.Add(new StartType() {Name = "Selvstart", ShortName = "M"});
                context.SaveChanges();
                var loc = new Location() {Name = "Arnborg"};
                context.Locations.Add(loc);
                context.SaveChanges();

                var club = new Club() { ClubId = 1, ShortName = "vgc2014", Name = "VGC Rally 2014", Location = loc, Website = "http://www.vgc2014.dk/" };
                context.Clubs.Add(club);
                context.SaveChanges();

                var importPlanes = @"2G, OY-AVX
Antonov A-15, 1967, OK-7906
Bergfalke III, OY-FHX, 1969
Skylark AZF 2B
BRIEGLEB BG12-16, OO-ZRV
Condor D-4854
Cumulus 3f, D-6059
Elfe S4a HB-1199
EON Olympia II, 1947, OY-XEF
ES-Ka-6 VH-GRS
Focke Wulf Kranich III, D-6018, 1952
Foka-4, 1964, D-9357
Foka-4, D-8802,1968
Grunau Baby 3, spann 13.8 m, D-6004, 1954
Grunau Baby 3, Werk Nr.004A, 1954
Grunau Baby AQN Gary Pullen
Grunau Baby Iib D-7156
Grunau Baby IIb, D-36 37, 1944,13,5m Spw.
Grunau-Baby III D-1977
Grunau-Baby III D-1977
Grunau-Baby III D-1977
Habicht D-8002
Habicht D-8002
Hol's der Teufel
Hütter 17, 1938, OY-CJX
Hütter 17, BGA 490
K6-CR D-5705
K6E, G-DCHB
K7, D-5250, 1957
Ka 2b Bj 1964, D-7042, WKNR 2008 AB
Ka 4 Rhönlerche, 1954 Frank Neupert
Ka 6 E - Rhönsegler, Bj. 1970, D-0463
Ka 6CR D-5705
KA13 Torpedo F-CCJJ
Ka2B D-8134 1956
Ka2B D-8134 1956
Ka2B D-8134 1956
Ka3, D-2397
Ka4 PH-279 Rhönlerche
Ka-4, PH-104
Ka6CR G-CHJP
Ka6cr PH-856
Ka6CR, 1959 D-8032
Ka6CR, 1964 Klaus Fey
Ka6CR, 1964 OY-XEA
Ka6CR, 1966 D-1212
Ka6E, 1966 D-4619
Ka6E, D-6375
Ka6E, D-6375
Ka-6E, G-CFCR
Ka-8b, PH-513
Kranch III, D-8543
Kranch III, D-8543, Werknr. 59, 1952
Kranich 3 D-6018
Kranich II b2 OY-XWL
L-55 Spatz HA-4210
L-55 Spatz HA-4210
L-Spatz 55, Bj 1957, WNr. 595, D-8262
L-Spatz 55, D-8310
L-Spatz, D-0283
Minimoa PH80
Minimoa PH80
Moswey III HB-374
Ka-2 HB-72
Mü13 D Geoff Moore and Rainer Karch
Mü13 D Geoff Moore and Rainer Karch
Nimbus 2B, 1974, D-8995
Pik-5c OH-188
Prefect PH-198
Prefect PH-198
R-11b Cimbora HA-5034
Röhnlerche Ka-4, PH-104, Prefect PH-192
Scheibe Bergfalke II, 1957 OY-BOX
Scheibe Bergfalke II/55 D-6413
Scheibe SF 26, 1964, OY-BJX
Scheibe SF 27M D-KHOA
Scheibe Specht, 1954/55, D-5551
Schleicher Ka-2, 1961 HB-724
Schleicher Ka2, D-8776, 1955
Schleicher Ka2, D-8776, 1955
SF-27 HB-3157
SF-27, 1967, D-1549, 15 m
SHK1, 1966, OY-FPX
SHK-1, D-8621, 1967 and K6-CR, D-8485, 1963
Skylark 4 BLZ
Skylark 4 BLZ
Slingsby T.30a Prefect PH-198
Slingsby T13 Petrel Graham Saw
Slingsby T21 Jörn Assmann
Slingsby T21 b, BGA-4135, 1952
Slingsby T21B Peter Hardman
Slingsby T21c Sedbergh, TopD'rop PH-110
Slingsby T31 XE-802
Slingsby T31 B, Tanden Tutor, 1952 HB-557
Slingsby T49 Capstan BPV
Slylark 4 Peter Boulton
Stamer-Lippisch (Zögling), 1926 / 1994, OY-XSE
SZD 36 Cobra D-6010
SZD22 Mucha Standard, SP-2279
SZD-22B, Mucha Standard, OY-XAI, 1960
SZD22MuchaStd Christopher Duthy-James
SZD-24 Foka Standard, 1961 OY-DCX
SZD-25 Lis OY-DXX
SZD9bis 1E Bocian Hans Dijkstra
SZD9bis 1E Bocian, 1975 D-8008
T21 Sedberg WJ306
Weihe 50 D-3654
Weihe 50 D-3654
Zugvogel IIIb, 1964 D-2999";

                var importPilots = @"Niels Poulsen
Peter Ocker
Nils Ludvig Møller
Brian Griffin
Jorn Hanssens
Reginald Kasubeck
Christian Kroll
Lilly-Annemarie Grundbacher
Tove Lund
Garret Russell
Ralf Schnirch
Gerhard Maleschka
Joachim Maleschka
Matthias Dubbick
Manfred Schwämmle
Gary Pullen
Rolf Bornheber
Sven Brandhorst
Heike Capell
Hermann Beiker
Reinhard Jacob
Philipp Stengele
Ulrich Stengele
Jiri Lenik
Niels Ebbe Gjørup
Nick Newton
Walther Hoekstra
Martin Hastings
Hubert Maleschka
Burkhard Wittje
Frank Neupert
Christoph Adel
Thomas van de Ven
Henrard Firmin
Nils Hansen
Gitta Jünemann
Manfred Müller-Christiansen
Johan van Dijk
Karel Dop
Robbie Vroegop
Dave Cornelius
Astrid van Lieshout
Jürgen Skucek
Klaus Fey
Ove Hillersborg
Marijke Wallkens
David Hall
Jessica Krüger
Jonas Majewski
Ray Whittaker
Peet Assmann
Josef Auer
Fritz Bauer
Rolf Braun
Johannes Lyng
Patrik Ungar
Sandor Plosz
Gerhard Tischler
Hartmut Sammet
Wolfgang Heller
Hans Disma
Peter Deege
Werner Rüegg
Kurt Stapfer
Geoff Moore
Rainer Karch
Christian Mathieu
Peter Brooks
Pekka Hänninen
Jim van Aalst
Mira M. van Aalst
Laszlo Revy
Frits Urselmann
Niels Taarnhøj
Christian Hülsheger
Niels Peder Møller
Frank-Dieter Lemke
Klaus Preen
Werner Roth
Alexander Gilles
Karl-Bernhard Hurrle
Peter Hartmann
Rainer Strobel
Frank Drinhaus
Werner Kalkhoff
Gerald Hill
Martin Hollowell
Bob van Aalst
Graham Saw
Jörn Assmann
Christian Langenau
Peter Hardman
Gerard Rijerse
Martin Smith
Beat Huber
Garry Cuthill
Peter Boulton
Erling Rasmussen
Ulf Kern
Barbara Reed
Per Brusgaard Pedersen
Christopher Duthy-James
Leif Midtbøll
Francis Humblet
Hans Dijkstra
Ullrich Hötling
David Weekes
Dr. Gerd Hermjacob
Engelbert Westerwalbesloh
Yves De Stobbeleir
Andreas Belke
Aurelia Breuer
Beat Galliker
Bill Batesole
Bruno Larsson
Camilla van Beugen
Carl H. Kristiansen
Claus-Dieter Garthe
Colin Simpson
Didier Fulchiron
Eberhard Jauer
Eberhard Strauss
Edgar Kraus
Egon-Manfred Paech
Elia Passerini
Erik Jensen
Ervin Moskovits
Georg Themann
Giesela Beyer
Graham Barrett
Hans Lööf
Hans Zima
Harald Kämper
Heikki Juhani Huuskonen
Hiltrud Garthe
Hwang Bo
Ingvar Hyllander
Jan Foster
Joachim Jeska
Johan Kieckens
Josef Mezera
Jürgen Burkhardt
Kimmo Tihula
Klaus Schickling
Leif Nilsson
Liptai Nándor
Lothar Ewigleben
Marja Osinga-Meek
Martin Douglas Cooper
Neelco Osinga
Olle Erikson
Otto Deli
Patrick Zimmer
Péter Moskovits
Péter Szakács
Rainer Schardt
Reinier Smit
Robert Stikkelbroeck
Roland Sturm
Rolf Algotson
Russell Hardcastle
Stig Karsson
Sven Holzberg
Szotirisz Kiatipisz
Teun van Rijswijck
Thorsten kremer
Ulf Ewert
Werner Kaluza
Wolfgang Beyer
Wolfgang Ulrich
Zoltan Verebelyi";

                PlaneController.ImportPlanesFromTextarea(importPlanes);
                PilotController.ImportPilotsFromTextarea(importPilots);

            }

            public static void InitializeDemoFlightsForEF(FlightContext context)
            {
                // StartType
                var start = new StartType() {Name = "Spilstart", ShortName = "S"};
                context.StartTypes.Add(start);
                context.StartTypes.Add(new StartType() {Name = "Flyslæb", ShortName = "F"});
                context.StartTypes.Add(new StartType() {Name = "Selvstart", ShortName = "M"});
                context.SaveChanges();

                // Locations
                var location = new Location {Name = "Kongsted"};
                context.Locations.Add(location);
                context.Locations.Add(new Location() {Name = "Arnborg"});
                context.SaveChanges();

                // Clubs
                var club = new Club() {ClubId = 38, ShortName = "ØSF", Name = "Øst-Sjællands Flyveklub", Location = location};
                context.Clubs.Add(club);
                context.SaveChanges();

                // Planes
                var pl2 = new Plane
                {
                    CompetitionId = "R2",
                    Registration = "OY-XMO",
                    Seats = 2,
                    DefaultStartType = start,
                    Engines = 0
                };
                context.Planes.Add(pl2);
                var pla = new Plane
                {
                    CompetitionId = "RR",
                    Registration = "OY-RRX",
                    Seats = 2,
                    DefaultStartType = start,
                    Engines = 1
                };
                context.Planes.Add(pla);
                var pl1 = new Plane
                {
                    CompetitionId = "PU",
                    Registration = "OY-XPU",
                    Seats = 1,
                    DefaultStartType = start,
                    Engines = 0
                };
                context.Planes.Add(pl1);
                context.SaveChanges();

                // Pilots
                var pilot = new Pilot {Name = "Jan Hebnes", MemberId = "1241", Club = club};
                context.Pilots.Add(pilot);
                context.Pilots.Add(new Pilot {Name = "Søren Sarup", MemberId = "1125", Club = club});

                context.SaveChanges();
                var s = new List<Flight>
                {
                    new Flight
                    {
                        Departure = DateTime.Now.AddHours(-3),
                        Landing = DateTime.Now.AddHours(-3).AddMinutes(15),
                        Plane = pl1,
                        StartedFrom = location,
                        LandedOn = location,
                        Pilot = pilot,
                        StartType = start,
                        Description = "Demo flight",
                        LastUpdatedBy = pilot.ToString()
                    },
                    new Flight
                    {
                        Plane = pl2,
                        StartedFrom = location,
                        Pilot = pilot,
                        StartType = start,
                        Description = "Demo flight (login with admin@admin.com and password Admin@123456",
                        LastUpdatedBy = pilot.ToString()
                    },
                    new Flight
                    {
                        Departure = DateTime.Now.AddHours(-2),
                        Plane = pl2,
                        StartedFrom = location,
                        Pilot = pilot,
                        StartType = start,
                        LastUpdatedBy = pilot.ToString(),
                        Description = "Demo flight"
                    },
                    new Flight
                    {
                        Departure = DateTime.Now.AddHours(-1),
                        Plane = pl2,
                        StartedFrom = location,
                        Pilot = pilot,
                        StartType = start,
                        Description = "Demo flight",
                        LastUpdatedBy = pilot.ToString()
                    },
                    new Flight
                    {
                        Departure = DateTime.Now.AddHours(-4),
                        Plane = pl2,
                        StartedFrom = location,
                        Pilot = pilot,
                        StartType = start,
                        LastUpdatedBy = pilot.ToString(),
                        Description = "Demo flight"
                    },
                    new Flight
                    {
                        Departure = DateTime.Now.AddHours(-3).AddMinutes(10),
                        Plane = pl2,
                        StartedFrom = location,
                        Pilot = pilot,
                        StartType = start,
                        Description = "Demo flight",
                        LastUpdatedBy = pilot.ToString()
                    }
                };
                s.ForEach(b => context.Flights.Add(b));
                context.SaveChanges();
            }
        }
#endif
    }
}
