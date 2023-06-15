using AutoMapper;
using CodeAcademy.DAL;
using CodeAcademy.DTO;
using CodeAcademy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeAcademy.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly CodeAcademyDbContext _context;
        private readonly IMapper _map;

        public CategoryController(CodeAcademyDbContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        [HttpGet("/cate")]
        public IActionResult GetAllcategory()
        {
            List<Category> cate = _context.Categories.ToList();

            if (cate is null) return NotFound();
            return Ok(cate);
        }

    }
}
