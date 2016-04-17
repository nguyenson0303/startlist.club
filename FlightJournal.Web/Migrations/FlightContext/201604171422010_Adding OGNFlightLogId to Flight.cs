namespace FlightJournal.Web.Migrations.FlightContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOGNFlightLogIdtoFlight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "OGNFlightLogId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "OGNFlightLogId");
        }
    }
}
