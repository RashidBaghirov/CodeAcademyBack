namespace CodeAcademy.Entities
{
    public class EducationMode : BaseEntity
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string DetailImage { get; set; }

        public string Detail_Questions { get; set; }

        public string Detail_Answer { get; set; }
        public string Detail_Desc { get; set; }

        public string Others { get; set; }
        public string Purpose { get; set; }
        public string Hastage { get; set; }
        public List<Profession> Professions { get; set; }
        public List<ModePhotos> ModePhotos { get; set; }
        public List<Teacher> Teachers { get; set; }



        public EducationMode()
        {
            Professions = new();
            ModePhotos = new();
        }
    }
}
