namespace CodeAcademy.Entities
{
    public class Teacher : BaseEntity
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Desc { get; set; }

        public int EducationModeId { get; set; }
        public EducationMode EducationMode { get; set; }

    }
}
