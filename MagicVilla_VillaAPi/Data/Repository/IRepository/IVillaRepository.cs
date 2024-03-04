using MagicVilla_VillaAPi.Data.Models;

namespace MagicVilla_VillaAPi.Data.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entry);
    }
}
