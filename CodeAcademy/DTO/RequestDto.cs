using System.ComponentModel.DataAnnotations;

namespace CodeAcademy.DTO
{
    public class RequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        public string EmployeeCount { get; set; }

        public string AdditionalInfo { get; set; }
    }
}
