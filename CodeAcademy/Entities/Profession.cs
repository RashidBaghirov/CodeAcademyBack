namespace CodeAcademy.Entities
{
    public class Profession : BaseEntity
    {
        public string Name { get; set; }
        public List<Accordion> Accordions { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int EducationModeId { get; set; }
        public EducationMode EducationMode { get; set; }


        public Profession()
        {
            Accordions = new();
        }
    }
}
