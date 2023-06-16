namespace CodeAcademy.Entities
{
    public class Graduant:BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public string Sentence { get; set; }
        public string Image { get; set; }

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }

        public string Answer3 { get; set; }

        public string Answer4 { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }


        public int EducationModeId { get; set; }
        public EducationMode EducationMode { get; set; }

    }
}
