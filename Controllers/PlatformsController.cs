using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms() 
        { 
            var res = _repo.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(res));
        }


        [HttpGet(Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int Id)
        { 
            var plat = _repo.GetPlatformById(Id);
            if (plat == null) return NotFound();
            return Ok(_mapper.Map<PlatformReadDto>(plat));
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatforCreateDto dto)
        {
            Platform plat = _mapper.Map<Platform>(dto);
            _repo.CreatePlatform(plat);
            _repo.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(plat);
            return CreatedAtRoute(nameof(GetPlatformById), new { platformReadDto.Id }, platformReadDto);
        }
    }
}
