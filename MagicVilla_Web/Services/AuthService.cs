using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using static MagicVilla_Utility.SD;

namespace MagicVilla_Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _client;
        private readonly IBaseService _baseService;
        private string apiUrl;
        public AuthService(IHttpClientFactory client , IConfiguration configuration, IBaseService baseService)
        {
            _client = client;
            _baseService = baseService;
            apiUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }
        public async Task<T> LoginAsync<T>(LoginRequestDTO objToCreate)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.POST,
                Data = objToCreate,
                Url = apiUrl + "/api/v1/UsersAuth/login"
            } , withBearer:false);
        }

        public async Task<T> RegisterAsync<T>(RegisterationRequestDTO objToCreate)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.POST,
                Data = objToCreate,
                Url = apiUrl + "/api/v1/UsersAuth/register"
            }, withBearer: false);
        }
    }
}
