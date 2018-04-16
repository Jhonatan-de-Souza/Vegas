using System.Threading.Tasks;

namespace Vegas.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}