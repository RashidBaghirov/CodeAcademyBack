using AutoMapper;
using CodeAcademy.DAL;
using CodeAcademy.DTO;
using CodeAcademy.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademy.Controllers
{
    public class RequestController : ControllerBase
    {
        private readonly CodeAcademyDbContext _context;
        private readonly IMapper _map;

        public RequestController(CodeAcademyDbContext context,IMapper map)
        {
            _context = context;
            _map = map;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateRequest([FromBody] RequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Request request = _map.Map<Request>(requestDto);

            request.Date = DateTimeOffset.Now;

            request.IsReply = false;

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }

}
