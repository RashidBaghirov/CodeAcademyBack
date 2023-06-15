using CodeAcademy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAcademy.Configurations
{
    public class EduModelConfiguration : IEntityTypeConfiguration<EduModel>
    {

        public void Configure(EntityTypeBuilder<EduModel> builder)
        {

            builder.Property(b => b.Name_left).HasMaxLength(20).IsRequired();
            builder.Property(b => b.Name_right).HasMaxLength(20).IsRequired();
        }
    }
}
