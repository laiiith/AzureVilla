using MagicVilla_VillaAPi.Data.Models;

namespace MagicVilla_VillaAPi.Data.Models.DTO
{
    public class LoginResponseDTO
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
