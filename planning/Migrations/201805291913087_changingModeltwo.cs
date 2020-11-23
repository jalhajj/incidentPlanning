namespace planning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingModeltwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidents", "PriorityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Incidents", "PlannedFor", c => c.DateTime());
            AlterColumn("dbo.Incidents", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Incidents", "Date", c => c.DateTime());
            AlterColumn("dbo.Incidents", "OpenedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incidents", "OpenedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Incidents", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Incidents", "UserId", c => c.String());
            AlterColumn("dbo.Incidents", "PlannedFor", c => c.DateTime(nullable: false));
            DropColumn("dbo.Incidents", "PriorityId");
        }
    }
}
