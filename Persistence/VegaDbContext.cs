using Microsoft.EntityFrameworkCore;
using Vega.Core.Models;
using Vegas.Core.Models;

namespace Vega.Persistence
{
    public class VegaDbContext : DbContext
    {
       public DbSet<Make> Makes {get;set;}
       public DbSet<Features> Features {get;set;}
       public DbSet<Vehicle> Vehicles { get; set; }
       public DbSet<Fighter> Fighters { get; set; }
       public DbSet<Skills> Skills { get; set; }
        public VegaDbContext(DbContextOptions <VegaDbContext> options)
        :base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //This is similar to fluentAPI    in order to create a composite key
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.VehicleId, vf.FeatureId }); 
            modelBuilder.Entity<FighterSkill>().HasKey(ck => new {ck.FighterId,ck.SkillId});
        }
    }
}