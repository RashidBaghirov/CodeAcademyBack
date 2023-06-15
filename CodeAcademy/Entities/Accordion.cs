namespace CodeAcademy.Entities
{
    public class Accordion : BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public Profession Profession { get; set; }
        public int ProfessionId { get; set; }

    }
}
