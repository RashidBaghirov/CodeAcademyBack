using AutoMapper;
using CodeAcademy.DAL;
using CodeAcademy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeAcademy.Controllers
{
    public class GraduantController : ControllerBase
    {
        private readonly CodeAcademyDbContext _context;
        private readonly IMapper _mapper;

        public GraduantController(CodeAcademyDbContext context, IMapper mapper)
        {
          _context = context;
           _mapper = mapper;
        }
        [HttpGet("/graduant")]
        public IActionResult Index()
        {
            List<Graduant> graduants = _context.Graduants.Include(x => x.EducationMode).AsNoTracking().ToList();
            return Ok(graduants);
        }

        [HttpGet("/graduant/{id}")]
        public IActionResult GraduantDetail(int id)
        {
            if (id == 0) return NotFound();
           Graduant graduant = _context.Graduants.Include(x => x.EducationMode).ThenInclude(x=>x.ModePhotos).AsNoTracking().FirstOrDefault(x=>x.Id==id);
            if (graduant is null) return NotFound();
            return Ok(graduant);
        }


        [HttpGet("/graduantrelated/{id}")]
        public IActionResult GraduantDetailRelated(int id)
        {
            if (id == 0) return NotFound();

            List<Graduant> graduants = _context.Graduants
                .Where(g => g.Id != id)
                .Take(3)
                .ToList();

            if (graduants.Count == 0) return NotFound();

            return Ok(graduants);
        }



    }
}
