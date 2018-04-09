using Microsoft.EntityFrameworkCore;
using Vegas.Models;

namespace Vegas.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions <VegaDbContext> options)
        :base(options)
        {
        }
       public DbSet<Make> Makes {get;set;}
    }
}