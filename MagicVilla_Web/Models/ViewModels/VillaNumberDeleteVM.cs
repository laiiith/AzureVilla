using MagicVilla_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.ViewModels
{
    public class VillaNumberDeleteVM
    {
        public VillaNumberDeleteVM()
        {
            VillaNumberDTO = new VillaNumberDTO();
        }
        public VillaNumberDTO VillaNumberDTO { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ListVilla { get; set; }
    }
}
