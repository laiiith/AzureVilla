using MagicVilla_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.ViewModels
{
    public class VillaNumberUpdateVM
    {
        public VillaNumberUpdateVM()
        {
            VillaNumberDTO = new VillaNumberUpdateDTO();
        }
        public VillaNumberUpdateDTO VillaNumberDTO { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ListVilla { get; set; }
    }
}
