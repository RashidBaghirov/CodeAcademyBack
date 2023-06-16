namespace CodeAcademy.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Profession> Professions { get; set; }

        public Category()
        {
            Professions = new();
        }
    }
}
