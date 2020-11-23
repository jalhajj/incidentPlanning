namespace planning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinginciNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidents", "IncidentNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incidents", "IncidentNumber");
        }
    }
}
