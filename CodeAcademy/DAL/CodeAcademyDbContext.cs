using CodeAcademy.Configurations;
using CodeAcademy.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeAcademy.DAL
{
    public class CodeAcademyDbContext : DbContext
    {
        public CodeAcademyDbContext(DbContextOptions<CodeAcademyDbContext> options) : base(options)
        {

        }


        public DbSet<Slider> Sliders { get; set; }
        public DbSet<EducationMode> EducationModes { get; set; }
        public DbSet<EduModel> EduModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Accordion> Accordions { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ModePhotos> ModePhotos { get; set; }
        public DbSet<Cource> Cources { get; set; }
        public DbSet<Partnyor> Partnyors { get; set; }
        public DbSet<Graduant> Graduants { get; set; }
        public DbSet<Request> Requests { get; set; }









        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new EduModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
