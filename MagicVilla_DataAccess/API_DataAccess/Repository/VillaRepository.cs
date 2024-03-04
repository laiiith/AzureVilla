using MagicVilla_DataAccess.API_DataAccess.Repository.IRepository;
using MagicVilla_Models.API_Models;


namespace MagicVilla_DataAccess.API_DataAccess.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Villa> UpdateAsync(Villa entry)
        {
            entry.UpdatedDate = DateTime.Now;
            _db.Villas.Update(entry);
            await _db.SaveChangesAsync();
            return entry;
        }
    }
}
