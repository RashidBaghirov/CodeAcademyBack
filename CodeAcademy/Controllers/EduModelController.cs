using AutoMapper;
using CodeAcademy.DAL;
using CodeAcademy.DTO;
using CodeAcademy.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademy.Controllers
{
    public class EduModelController : ControllerBase
    {
        private readonly CodeAcademyDbContext _context;
        private readonly IMapper _map;

        public EduModelController(CodeAcademyDbContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        [HttpGet("/edu")]
        public IActionResult Index()
        {
            List<EduModel> models = _context.EduModels.ToList();
            List<EduModelGet> modelGets = _map.Map<List<EduModelGet>>(models);
            return Ok(modelGets);
        }

        [HttpGet("/edu/{id}")]
        public async Task<IActionResult> GetEduById(int id)
        {
            if (id == 0) return NoContent();
            EduModel model = _context.EduModels.FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
