using System.Linq.Expressions;

namespace MagicVilla_DataAccess.API_DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task CreateAsync(T entry);
        Task RemoveAsync(T entry);
        Task SaveAsync();


    }
}
