using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FlightJournal.Web.Controllers;
using FlightJournal.Web.Models;
using Owin;
using Hangfire;
using Hangfire.SqlServer;

namespace FlightJournal.Web
{
    public partial class Startup
    {
        public void ConfigureHangfire(IAppBuilder app)
        {
            // http://docs.hangfire.io/en/latest/quick-start.html

            //This will create the DB if it doesn't exist
            using (var db = new HangfireContext())
            {
                db.SaveChanges();
            }

            var options = new SqlServerStorageOptions
            {
                PrepareSchemaIfNecessary = true,
                QueuePollInterval = TimeSpan.FromMinutes(1)
            };

            GlobalConfiguration.Configuration.UseSqlServerStorage("FlightJournal.Hangfire", options);
            //app.UseHangfireDashboard();
            app.UseHangfireServer();

            // Make sure we call the synchronizer daily so historic events are stored permanently
            RecurringJob.AddOrUpdate(() => OpenGliderNetworkController.Synchronize(), Cron.Daily);
        }

        //http://stackoverflow.com/questions/27952142/using-hangfire-connection-string-given-in-startup-cs-throws-cannot-attach-file
        public class HangfireContext : DbContext
        {
            public HangfireContext() : base("name=FlightJournal.Hangfire")
            {
                Database.SetInitializer<HangfireContext>(null);
                Database.CreateIfNotExists();
            }
        }
    }
}