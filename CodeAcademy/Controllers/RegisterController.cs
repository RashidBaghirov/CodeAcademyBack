using CodeAcademy.DAL;
using CodeAcademy.DTO;
using CodeAcademy.Entities;
using CodeAcademy.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace CodeAcademy.Controllers
{
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly CodeAcademyDbContext _context;

        public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager, CodeAcademyDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Email = registerDto.Email,
                UserName = registerDto.Username
            };

            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "This email address is already in use.");
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest(ModelState);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Action(nameof(VerifyEmail), "Register", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());

            var mail = new MailMessage();
            mail.From = new MailAddress("codea812@gmail.com", "CodeAcademy");
            mail.To.Add(new MailAddress(user.Email));
            mail.Subject = "Confirm Email";
            string body = "You can verify your email address by clicking on the link: <a href=\"" + callbackUrl + "\">Click here</a>";
            mail.Body = body;
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("codea812@gmail.com", "diheghgwjfxguoyh");
                await smtp.SendMailAsync(mail);
            }
            await _userManager.AddToRoleAsync(user, Roles.admin.ToString());

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return Redirect("http://localhost:3000/");
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpGet]
        //[Route("roles")]
        //public async Task Createroles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole(Roles.superadmin.ToString()));
        //    await _roleManager.CreateAsync(new IdentityRole(Roles.admin.ToString()));
        //    await _roleManager.CreateAsync(new IdentityRole(Roles.moderator.ToString()));
        //}
    }
}
