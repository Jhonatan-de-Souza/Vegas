using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Core;
using Vega.Core.Models;

namespace Vega.Persistence
{
    public class FighterRepository : IFighterRepository
    {
        private readonly VegaDbContext context;
        public FighterRepository(VegaDbContext context)
        {
            this.context = context;
        }

        public void Add(Fighter fighter)
        {
            context
                .Add(fighter);
        }
        

        public async Task<Fighter> GetFighterByIdAsync(int id)
        {
            var testResults = await context.Fighters.ToListAsync(); // remove later
            var testResults2 = await context.Fighters
            .Include(x=>x.Skills)
                .ThenInclude(xf => xf.Skill)
                .Where(filter => filter.Id == id)
                .FirstOrDefaultAsync();
            
            var results = await context.Fighters
                .Where(x=>x.Id == id)
                .Include(x=>x.Skills)
                .FirstOrDefaultAsync();
            return results;
        }

        public  async Task<IEnumerable<Fighter>> GetFighterAsync()
        {
            var test = await context.Fighters.ToListAsync();
            var results =  await context.Fighters
                .Include(v => v.Skills)
                    .ThenInclude(vf => vf.Skill)
                .ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Skill>> GetSkillsAsync()
        {
            return await context.Skills
                .ToListAsync();
        }
    }
}