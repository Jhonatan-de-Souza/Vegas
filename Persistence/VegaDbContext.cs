using Microsoft.EntityFrameworkCore;
using Vegas.Models;

namespace Vegas.Persistence
{
    public class VegaDbContext : DbContext
    {
       public DbSet<Make> Makes {get;set;}
       public DbSet<Features> Features {get;set;}
        public VegaDbContext(DbContextOptions <VegaDbContext> options)
        :base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //This is similar to fluentAPI   
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.VehicleId, vf.FeatureId }); 
        }
    }
}