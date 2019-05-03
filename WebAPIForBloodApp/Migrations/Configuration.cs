namespace WebAPIForBloodApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAPIForBloodApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPIForBloodApp.Models.DatabaseBloodAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAPIForBloodApp.Models.DatabaseBloodAppDbContext context)
        {

            context.Users.AddOrUpdate(x => x.ID,
                new User()
                {
                    ID = 1,
                    Email = "admin@admin",
                    Password = "admin",
                    FirstName = "admin",
                    LastName = "admin",
                    DateOfBirth = DateTime.ParseExact("01/01/1990 12:00:00", "dd/MM/yyyy HH:mm:ss", null),
                    DateOfLastDonation = DateTime.ParseExact("01/01/2018 15:00:00", "dd/MM/yyyy HH:mm:ss", null),
                }
                );

            context.BloodTypes.AddOrUpdate(x => x.ID,
                new BloodType()
                {
                    ID = 1,
                    Type = "A-"
                },
                new BloodType()
                {
                    ID = 2,
                    Type = "A+"
                },
                new BloodType()
                {
                    ID = 3,
                    Type = "0-"
                },
                new BloodType()
                {
                    ID = 4,
                    Type = "0+"
                },
                new BloodType()
                {
                    ID = 5,
                    Type = "B+"
                },
                new BloodType()
                {
                    ID = 6,
                    Type = "B-"
                },
                new BloodType()
                {
                    ID = 7,
                    Type = "AB+"
                },
                new BloodType()
                {
                    ID = 8,
                    Type = "AB-"
                }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
