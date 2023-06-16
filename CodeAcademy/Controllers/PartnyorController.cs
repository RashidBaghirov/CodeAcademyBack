using AutoMapper;
using CodeAcademy.DAL;
using CodeAcademy.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademy.Controllers
{
    public class PartnyorController : ControllerBase
    {
        private readonly CodeAcademyDbContext _context;
        private readonly IMapper _map;

        public PartnyorController(CodeAcademyDbContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        [HttpGet("/partnyor")]
        public IActionResult Index()
        {
            List<Partnyor> partnyors = _context.Partnyors.ToList();
            return Ok(partnyors);
        }
    }
}
