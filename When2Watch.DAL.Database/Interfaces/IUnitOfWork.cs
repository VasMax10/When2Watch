using System.Threading.Tasks;

namespace When2Watch.DAL.Database.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
