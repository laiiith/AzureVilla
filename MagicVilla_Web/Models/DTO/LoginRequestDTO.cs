using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.DTO
{ 
    public class LoginRequestDTO
    {
        [Required]
        [DisplayName("Email")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
