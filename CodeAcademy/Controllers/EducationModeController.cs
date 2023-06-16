using AutoMapper;
using CodeAcademy.DAL;
using CodeAcademy.DTO;
using CodeAcademy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeAcademy.Controllers
{
    public class EducationModeController : ControllerBase
    {
        private readonly CodeAcademyDbContext _context;
        private readonly IMapper _map;

        public EducationModeController(CodeAcademyDbContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        [HttpGet("/mode")]
        public IActionResult Index()
        {
            List<EducationMode> modes = _context.EducationModes.ToList();
            List<EducationModeGet> modeGets = _map.Map<List<EducationModeGet>>(modes);
            return Ok(modeGets);
        }
        [HttpGet("/mode/{id}")]
        public IActionResult GetEducationById(int id)
        {
            if (id == 0)
                return NoContent();

            EducationMode mode = _context.EducationModes
                .Include(x => x.Professions).ThenInclude(x => x.Category)
                .Include(x => x.ModePhotos)
                .Include(x => x.Teachers).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (mode == null)
                return NotFound();

            return Ok(mode);
        }


        [HttpGet("/profession/{id}")]
        public IActionResult GetProfessionById(int id)
        {
            if (id == 0)
                return NoContent();

            Profession profession = _context.Professions
                .Include(x => x.EducationMode).ThenInclude(x => x.ModePhotos)
                .Include(x => x.Accordions)
                              .Include(x => x.EducationMode).ThenInclude(x => x.Teachers)
                              .Include(x => x.EducationMode).ThenInclude(x => x.Cources)

                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (profession == null)
                return NotFound();

            return Ok(profession);
        }



        [HttpGet("/teacher/{id}")]
        public IActionResult GetTeacherId(int id)
        {
            if (id == 0)
                return NoContent();

            Teacher teacher = _context.Teachers.Include(x => x.EducationMode).ThenInclude(x=>x.Professions).AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (teacher is null) return NotFound();
            return Ok(teacher);
        }

    }
}
