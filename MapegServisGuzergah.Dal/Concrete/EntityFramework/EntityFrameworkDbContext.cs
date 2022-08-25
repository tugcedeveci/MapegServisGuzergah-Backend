using MapegServisGuzergah.Dal.Concrete.EntityFramework.Configuration;
using MapegServisGuzergah.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Dal.Concrete.EntityFramework
{
    public class EntityFrameworkDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFrameworkDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public EntityFrameworkDbContext(DbContextOptions<EntityFrameworkDbContext> options) : base(options) { }

        public EntityFrameworkDbContext() : base()
        {
            
        }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }    

        public DbSet<Voyage> Voyages { get; set; }

        public DbSet<VoyageStations> VoyageStations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=servisdb;Integrated Security=true;Pooling=true;", options => options.UseNetTopologySuite());

            optionsBuilder.UseLazyLoadingProxies(true);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("postgis");
            builder.HasDefaultSchema("public");

            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new StationConfiguration());
            builder.ApplyConfiguration(new RouteConfiguration());
            builder.ApplyConfiguration(new VoyageConfiguration());
            builder.ApplyConfiguration(new VoyageStationConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
