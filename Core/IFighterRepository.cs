using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vegas.Core.Models
{
    public interface IFighterRepository
    {
        Task<IEnumerable<Fighter>> GetFighterAsync();
        Task<Fighter> GetFighterByIdAsync(int id);
    }
}