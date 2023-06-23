using System.ComponentModel.DataAnnotations;

namespace CodeAcademy.DTO
{
    public class RequestGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        public string EmployeeCount { get; set; }

        public string AdditionalInfo { get; set; }
        public bool IsReply { get; set; }
    }
}
