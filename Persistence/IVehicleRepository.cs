using System.Threading.Tasks;
using Vegas.Models;

namespace Vegas.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id);
    }
}