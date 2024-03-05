using MagicVilla_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.ViewModels
{
    public class VillaNumberVM
    {
        public VillaNumberCreateDTO VillaNumberDTO { get; set; }
        public IEnumerable<SelectListItem> ListVilla { get; set; }
    }
}
