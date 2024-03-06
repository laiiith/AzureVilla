using MagicVilla_VillaAPi.Data;
using MagicVilla_VillaAPi.Data.Models;
using MagicVilla_VillaAPi.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla_VillaAPi.Data.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        private DbSet<VillaNumber> dbSet;
        public VillaNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            dbSet = _db.Set<VillaNumber>();
        }
        public async Task<VillaNumber> UpdateAsync(VillaNumber entry)
        {
            entry.UpdatedDate = DateTime.Now;
            dbSet.Update(entry);
            await _db.SaveChangesAsync();
            return entry;
        }
    }
}
