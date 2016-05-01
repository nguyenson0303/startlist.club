namespace FlightJournal.Web.Migrations.FlightContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOGNFlightLogIdtoFlightVersionHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlightVersionHistory", "OGNFlightLogId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlightVersionHistory", "OGNFlightLogId");
        }
    }
}
