using Microsoft.AspNetCore.Identity;

namespace MagicVilla_VillaAPi.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
