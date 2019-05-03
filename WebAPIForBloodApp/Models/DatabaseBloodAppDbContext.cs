using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPIForBloodApp.Models
{
    public class DatabaseBloodAppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<BloodUnit> BloodUnits { get; set; }
    }
}