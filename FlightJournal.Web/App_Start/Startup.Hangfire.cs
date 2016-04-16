using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightJournal.Web.Models;
using Owin;
using Hangfire;

namespace FlightJournal.Web
{
    public partial class Startup
    {
        public void ConfigureHangfire(IAppBuilder app)
        {
            // http://docs.hangfire.io/en/latest/quick-start.html

            GlobalConfiguration.Configuration.UseSqlServerStorage("FlightJournal.Hangfire");
            //app.UseHangfireDashboard();
            app.UseHangfireServer();

            // Make sure we call the synchronizer daily so historic events are stored permanently
            RecurringJob.AddOrUpdate(() => OpenGliderNetworkManager.Synchronize(), Cron.Daily);
        }
    }
}