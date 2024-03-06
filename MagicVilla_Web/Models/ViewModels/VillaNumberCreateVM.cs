using MagicVilla_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.ViewModels
{
    public class VillaNumberCreateVM
    {
        public VillaNumberCreateVM()
        {
            VillaNumberDTO = new VillaNumberCreateDTO();
        }
        public VillaNumberCreateDTO VillaNumberDTO { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ListVilla { get; set; }
    }
}
