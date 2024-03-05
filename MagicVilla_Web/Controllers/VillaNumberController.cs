using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.ViewModels;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVillaNumberService _service;
        private readonly IVillaService _villaService;
        public VillaNumberController(IMapper mapper , IVillaNumberService service, IVillaService villaService)
        {
            _mapper = mapper;
            _service = service;
            _villaService = villaService;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                List<VillaNumberDTO> list =  JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
                return View(list);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberVM vm;
            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                var list = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
                vm = new()
                {
                    ListVilla = list.Select(u=> new SelectListItem
                    {
                        Text = u.Villa.Name,
                        Value = u.VillaId.ToString()
                    })
                };
                return View(vm);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateDTO dto)
        {
            var response = await _service.CreateAsync<APIResponse>(dto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

                return BadRequest();
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateVillaNumber(int id)
        {
            var response = await _service.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                VillaNumberDTO model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result)); 
                return View(_mapper.Map<VillaNumberUpdateDTO>(model));
            }
                return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateDTO dto)
        {
            var response = await _service.UpdateAsync<APIResponse>(dto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        
        [HttpGet]
        public async Task<IActionResult> DeleteVillaNumber(int id)
        {
            var response = await _service.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                VillaNumberDTO model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDTO dto)
        {
            var response = await _service.DeleteAsync<APIResponse>(dto.VillaNo);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

    }
}
