using AutoMapper;
using CodeAcademy.DAL;
using CodeAcademy.DTO;
using CodeAcademy.Entities;
using CodeAcademy.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademy.Controllers
{
    public class SliderController : ControllerBase
    {
        private readonly CodeAcademyDbContext _context;
        private readonly IMapper _map;

        public SliderController(CodeAcademyDbContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        [HttpGet("/slider")]
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            List<SliderGet> sliderDto = _map.Map<List<SliderGet>>(sliders);
            return Ok(sliderDto);
        }
    }
}
