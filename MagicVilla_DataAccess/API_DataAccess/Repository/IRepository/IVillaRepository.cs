using MagicVilla_Models.API_Models;

namespace MagicVilla_DataAccess.API_DataAccess.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entry);
    }
}
