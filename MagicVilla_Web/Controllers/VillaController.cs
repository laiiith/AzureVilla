﻿using AutoMapper;
using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _service;
        private readonly IMapper _mapper;

        public VillaController(IMapper mapper, IVillaService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new();

            var response = await _service.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateVilla()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> CreateVilla(VillaCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa Created Successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error Encountered";
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateVilla(int id)
        {
            var response = await _service.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                
                return View(_mapper.Map<VillaUpdateDTO>(model));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa Updated Successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error Encountered";
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            var response = await _service.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDTO model)
        {

            var response = await _service.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa Deleted Successfully";
                return RedirectToAction(nameof(IndexVilla));
            }
            TempData["error"] = "Error Encountered";
            return View(model);
        }
    }
}
