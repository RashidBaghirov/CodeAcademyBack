using CodeAcademy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAcademy.Configurations
{
    public class EducationModelConfiguration : IEntityTypeConfiguration<EducationMode>
    {

        public void Configure(EntityTypeBuilder<EducationMode> builder)
        {
            builder.HasMany(x => x.ModePhotos)
                 .WithOne(x => x.EducationMode)
                 .HasForeignKey(x => x.EducationModeId);

            builder.HasMany(x => x.Teachers)
                .WithOne(x => x.EducationMode)
                .HasForeignKey(x => x.EducationModeId);
        }
    }
}
