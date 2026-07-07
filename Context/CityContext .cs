using CityGuide29.Markova.Classes.Database;
using CityGuide29.Markova.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuide29.Markova.Context
{
    public class CityContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public CityContext()
        {
            Database.EnsureCreated();
            Cities.Load();
            Attractions.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.connection, Config.version);
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<City>()
                .HasMany(c => c.Attractions)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
		}
	}
}
