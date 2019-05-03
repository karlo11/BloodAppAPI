namespace WebAPIForBloodApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraintBloodType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BloodTypes", "Type", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BloodTypes", "Type", c => c.String(nullable: false, maxLength: 2));
        }
    }
}
