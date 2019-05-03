namespace WebAPIForBloodApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BloodUnits", "BloodTypeID", c => c.Int());
            AddColumn("dbo.Users", "BloodTypeID", c => c.Int());
            CreateIndex("dbo.BloodUnits", "BloodTypeID");
            CreateIndex("dbo.Users", "BloodTypeID");
            AddForeignKey("dbo.BloodUnits", "BloodTypeID", "dbo.BloodTypes", "ID");
            AddForeignKey("dbo.Users", "BloodTypeID", "dbo.BloodTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "BloodTypeID", "dbo.BloodTypes");
            DropForeignKey("dbo.BloodUnits", "BloodTypeID", "dbo.BloodTypes");
            DropIndex("dbo.Users", new[] { "BloodTypeID" });
            DropIndex("dbo.BloodUnits", new[] { "BloodTypeID" });
            DropColumn("dbo.Users", "BloodTypeID");
            DropColumn("dbo.BloodUnits", "BloodTypeID");
        }
    }
}
