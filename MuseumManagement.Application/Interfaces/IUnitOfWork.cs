using System.Threading.Tasks;

namespace MuseumManagement.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
