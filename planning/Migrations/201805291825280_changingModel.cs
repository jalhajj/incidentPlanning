namespace planning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidents", "UserId", c => c.String());
            AlterColumn("dbo.Incidents", "PlannedFor", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Incidents", "Date", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Incidents", "OpenedDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incidents", "OpenedDate", c => c.DateTime());
            AlterColumn("dbo.Incidents", "Date", c => c.String());
            AlterColumn("dbo.Incidents", "PlannedFor", c => c.DateTime());
            DropColumn("dbo.Incidents", "UserId");
        }
    }
}
