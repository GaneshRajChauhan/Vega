using Microsoft.EntityFrameworkCore;
using Vega.Core.Models;

namespace Vega.persistance
{
    public class VegaDbContext:DbContext
    {

        public DbSet<Vehicle>  Vehicles { get; set; }
        public DbSet<Make> Makes {get;set;}
        public DbSet<Feature> features { get; set; }
        public VegaDbContext(DbContextOptions<VegaDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<VehicleFeatures>().HasKey(vf=> new{
                vf.VehicleId,vf.FeatureId
            });
}
        }
       
    }