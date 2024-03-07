using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using static MagicVilla_Utility.SD;

namespace MagicVilla_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _client;
        private string apiUrl;
        public AuthService(IHttpClientFactory client , IConfiguration configuration) : base(client)  
        {
            _client = client;
            apiUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }
        public async Task<T> LoginAsync<T>(LoginRequestDTO objToCreate)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.POST,
                Data = objToCreate,
                Url = apiUrl + "/api/v1/UsersAuth/login"
            });
        }

        public async Task<T> RegisterAsync<T>(RegisterationRequestDTO objToCreate)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.POST,
                Data = objToCreate,
                Url = apiUrl + "/api/v1/UsersAuth/register"
            });
        }
    }
}
