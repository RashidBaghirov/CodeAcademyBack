using CodeAcademy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAcademy.Configurations
{
    public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.HasMany(x => x.Accordions).
                WithOne(x => x.Profession)
                .HasForeignKey(x => x.ProfessionId);

            builder.HasOne(x => x.EducationMode)
                .WithMany(x => x.Professions).
                HasForeignKey(x => x.EducationModeId);
        }
    }
}
