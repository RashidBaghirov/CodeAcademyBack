using CodeAcademy.DAL;
using CodeAcademy.DTO;
using CodeAcademy.Entities;
using CodeAcademy.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;

namespace CodeAcademy.Controllers
{
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly CodeAcademyDbContext _context;

        public RegisterController(UserManager<User> usermanager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, CodeAcademyDbContext context)
        {
            _usermanager = usermanager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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

            var existingUser = await _usermanager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "This email address is already in use.");
                return BadRequest(ModelState);
            }

            var result = await _usermanager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest(ModelState);
            }

            var token = await _usermanager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action(nameof(VerifyEmail), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());

            var mail = new MailMessage();
            mail.From = new MailAddress("codea812@gmail.com", "CodeAcademy");
            mail.To.Add(new MailAddress(user.Email));
            mail.Subject = "Confirm Email";
            string body = "You can verify your email address by clicking on the link: <a href='" + link + "'>Click Here</a>.";
            mail.Body = body;
            mail.IsBodyHtml = true;
            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("codea812@gmail.com", "diheghgwjfxguoyh");
            smtp.Send(mail);
            await _usermanager.AddToRoleAsync(user, Roles.admin.ToString());

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            var user = await _usermanager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest();
            }

            var result = await _usermanager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return Ok();
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
