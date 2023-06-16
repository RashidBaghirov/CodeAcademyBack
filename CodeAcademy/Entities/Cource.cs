namespace CodeAcademy.Entities
{
    public class Cource:BaseEntity
    {
        public string Date { get; set; }
        public string Name { get; set; }

        public string CourceDay { get; set; }
        public int EducationModeId { get; set; }
        public EducationMode EducationMode { get; set; }
    }
}
