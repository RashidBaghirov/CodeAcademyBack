using CodeAcademy.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CodeAcademy.DTO
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public bool Terms { get; set; }
    }
}
