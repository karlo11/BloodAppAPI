namespace WebAPIForBloodApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBloodKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BloodUnits", "BloodTypeID", "dbo.BloodTypes");
            DropIndex("dbo.BloodUnits", new[] { "BloodTypeID" });
            AddColumn("dbo.BloodTypes", "BloodUnitID", c => c.Int());
            CreateIndex("dbo.BloodTypes", "BloodUnitID");
            AddForeignKey("dbo.BloodTypes", "BloodUnitID", "dbo.BloodUnits", "ID");
            DropColumn("dbo.BloodUnits", "BloodTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BloodUnits", "BloodTypeID", c => c.Int());
            DropForeignKey("dbo.BloodTypes", "BloodUnitID", "dbo.BloodUnits");
            DropIndex("dbo.BloodTypes", new[] { "BloodUnitID" });
            DropColumn("dbo.BloodTypes", "BloodUnitID");
            CreateIndex("dbo.BloodUnits", "BloodTypeID");
            AddForeignKey("dbo.BloodUnits", "BloodTypeID", "dbo.BloodTypes", "ID");
        }
    }
}
