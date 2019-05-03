namespace WebAPIForBloodApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTimesLocation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "TimeFrom", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Locations", "TimeTo", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "TimeTo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locations", "TimeFrom", c => c.DateTime(nullable: false));
        }
    }
}
