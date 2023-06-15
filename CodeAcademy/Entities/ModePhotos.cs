namespace CodeAcademy.Entities
{
    public class ModePhotos : BaseEntity
    {
        public string Image { get; set; }
        public int EducationModeId { get; set; }
        public EducationMode EducationMode { get; set; }
    }
}
