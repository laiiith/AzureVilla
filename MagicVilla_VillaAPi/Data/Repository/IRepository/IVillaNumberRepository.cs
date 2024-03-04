using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicVilla_VillaAPi.Data.Models;

namespace MagicVilla_VillaAPi.Data.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entry);

    }
}
