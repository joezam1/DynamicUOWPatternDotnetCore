using System.Threading.Tasks;
using project.Data.Context;
using project.Data.UnitOfWork;

namespace project.Data.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        DataContext _context {get; }
        Task<T> GetBySelectedIdAsync<T>(int id) where T : class, new();
        void SetEntitiesToInsert(UnitOfWorkEntity entity);
        void SetEntitiesToUpdate(UnitOfWorkEntity entity);
        void SetEntitiesToDelete(UnitOfWorkEntity entity);
        Task<int> Commit();
    }
}