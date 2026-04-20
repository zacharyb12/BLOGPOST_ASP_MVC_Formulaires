using BLOGPOST_ASP_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLOGPOST_ASP_MVC.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.Property(b => b.IsVisible)
                .HasDefaultValue(true);
        }
    }
}
