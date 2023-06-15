using CodeAcademy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAcademy.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(b => b.Name).HasMaxLength(20).IsRequired();
            builder.HasIndex(b => b.Name).IsUnique();
            builder.HasMany(x => x.Professions)
                 .WithOne(x => x.Category)
                 .HasForeignKey(x => x.CategoryId);
        }
    }
}
