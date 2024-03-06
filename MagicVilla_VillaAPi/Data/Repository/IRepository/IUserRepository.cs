using MagicVilla_VillaAPi.Data.Models;
using MagicVilla_VillaAPi.Data.Models.DTO;

namespace MagicVilla_VillaAPi.Data.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
