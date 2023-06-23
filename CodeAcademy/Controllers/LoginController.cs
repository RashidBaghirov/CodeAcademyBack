using CodeAcademy.DAL;
using CodeAcademy.DTO;
using CodeAcademy.Entities;
using CodeAcademy.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CodeAcademy.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly CodeAcademyDbContext _context;
        private readonly UserManager<User> _userManager;

        public LoginController(CodeAcademyDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [Authorize(Roles =nameof(Roles.superadmin)+","+ nameof(Roles.admin))]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }
            if (user.EmailConfirmed == false) return BadRequest();
            var isValidCredentials = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            var userRoles = await _userManager.GetRolesAsync(user);

            if (!isValidCredentials)
            {
                return BadRequest("Invalid credentials");
            }

            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GenerateRandomSymmetricKey(256); 

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Email, user.UserName),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        private byte[] GenerateRandomSymmetricKey(int keySizeInBits)
        {
            using (var provider = new RNGCryptoServiceProvider())
            {
                var keySizeInBytes = keySizeInBits / 8;
                var key = new byte[keySizeInBytes];
                provider.GetBytes(key);
                return key;
            }
        }

    }
}
