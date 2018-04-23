using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Persistence;
using Vegas.Core.Models;

namespace Vegas.Persistence
{
    public class FighterRepository : IFighterRepository
    {
        private readonly VegaDbContext context;
        public FighterRepository(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task<Fighter> GetFighterByIdAsync(int id)
        {
            return await context.Fighters.Where(x=>x.Id == id).FirstOrDefaultAsync();
        }

        async Task<IEnumerable<Fighter>> IFighterRepository.GetFighterAsync()
        {
            return await context.Fighters.ToListAsync();
        }
    }
}