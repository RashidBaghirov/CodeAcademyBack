using CodeAcademy.Entities;

namespace CodeAcademy.DTO
{
    public class CategoryGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<int> Professions { get; set; }

        public CategoryGet()
        {
            Professions = new();
        }
    }
}
