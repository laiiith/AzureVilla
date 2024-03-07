using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaNumberService :  IVillaNumberService
    {
        private readonly IHttpClientFactory _client;
        private string villaNumberUrl;
        private readonly IBaseService _baseService;
        public VillaNumberService(IHttpClientFactory client , IConfiguration configuration, IBaseService baseService) 
        {
            _client = client;
            villaNumberUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
            _baseService = baseService;

        }

        public async Task<T> CreateAsync<T>(VillaNumberCreateDTO dto)
        {
            return await _baseService.SendAsync<T>(new APIRequest() {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = villaNumberUrl + $"/api/{SD.CurrentAPIVersion}/VillaNumberAPI",
            });
        }

        public async Task<T> DeleteAsync<T>(int id)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaNumberUrl + $"/api/{SD.CurrentAPIVersion}/VillaNumberAPI/{id}",
            });
        }

        public async Task<T> GetAllAsync<T>()
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaNumberUrl + $"/api/{SD.CurrentAPIVersion}/VillaNumberAPI",
            });
        }

        public async Task<T> GetAsync<T>(int id)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaNumberUrl + $"/api/{SD.CurrentAPIVersion}/VillaNumberAPI/{id}",
            });
        }

        public async Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaNumberUrl + $"/api/{SD.CurrentAPIVersion}/VillaNumberAPI/{dto.VillaNo}",
            });
        }
    }
}
