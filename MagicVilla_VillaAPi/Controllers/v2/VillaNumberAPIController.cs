using AutoMapper;
using Azure;
using MagicVilla_VillaAPi.Data.Models;
using MagicVilla_VillaAPi.Data.Models.DTO;
using MagicVilla_VillaAPi.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace MagicVilla_VillaAPi.Controllers.v2
{
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]
    public class VillaNumberAPIController : ControllerBase
    {
        private readonly IVillaNumberRepository _repo;
        private readonly IVillaRepository _villaRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public VillaNumberAPIController(IVillaNumberRepository repo, IMapper mapper, IVillaRepository villaRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _villaRepo = villaRepo;
            _response = new();
        }


        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


    }
}
