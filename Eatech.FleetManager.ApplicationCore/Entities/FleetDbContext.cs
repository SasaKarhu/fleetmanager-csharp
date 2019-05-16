using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eatech.FleetManager.ApplicationCore.Entities
{
    

    public class FleetDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public FleetDbContext(DbContextOptions<FleetDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Car>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
