using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.Core.Models;

namespace Vega.Core
{
    public interface IFighterRepository
    {
        Task<IEnumerable<Fighter>> GetFighterAsync();
        Task<Fighter> GetFighterByIdAsync(int id);
        Task<IEnumerable<Skill>> GetSkillsAsync() ;
        void Add(Fighter fighter);
    }
}