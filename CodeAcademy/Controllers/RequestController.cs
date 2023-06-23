using AutoMapper;
using CodeAcademy.DAL;
using CodeAcademy.DTO;
using CodeAcademy.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace CodeAcademy.Controllers
{
    public class RequestController : ControllerBase
    {
        private readonly CodeAcademyDbContext _context;
        private readonly IMapper _map;

        public RequestController(CodeAcademyDbContext context, IMapper map)
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


        [HttpGet("/requests")]
        public async Task<IActionResult> AllRequests()
        {
            List<Request> requests = _context.Requests.AsNoTracking().ToList();
            List<RequestGetDto> requestGetDtos = _map.Map<List<RequestGetDto>>(requests);

            return Ok(requestGetDtos);
        }

        [HttpGet("/requestpendig")]
        public IActionResult GetRequestDetail()
        {

            List<Request> requests = _context.Requests.AsNoTracking().Where(x => x.IsReply == false).ToList();
            if (requests is null) return BadRequest();
            return Ok(requests);
        }


        [HttpPost("/replace/{id}")]
        public async Task<IActionResult> ReplaceRequest(int id, string replace)
        {
            if (id == 0) return NotFound();
            Request request = _context.Requests.FirstOrDefault(x => x.Id == id);
            if (request is null) return NotFound();
            MailMessage message = new MailMessage();
            message.From = new MailAddress("codea812@gmail.com", "Code Academy");
            message.To.Add(new MailAddress(request.Email));
            message.Subject = "Code Academy Support";
            message.Body = string.Empty;
            message.Body = $"{replace}";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential("codea812@gmail.com", "diheghgwjfxguoyh");
            smtpClient.Send(message);
            request.IsReply = true;
            _context.SaveChanges();
            return Ok();
        }



        [HttpPost("/deletedReplace/{id}")]

        public IActionResult DeleteRequest(int id)
        {
            if (id == 0) return NotFound();
            Request request = _context.Requests.FirstOrDefault(x => x.Id == id);
            if (request is null) return NotFound();
            _context.Requests.Remove(request);
            _context.SaveChanges();
            return Ok();
        }

    }

}
