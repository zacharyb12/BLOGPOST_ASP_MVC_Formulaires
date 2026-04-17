using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    internal class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .HasMaxLength(50);

            builder.Property(b => b.Content)
                    .HasMaxLength(500);

            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(b => b.IsVisible)
                    .HasDefaultValue(true);

            builder.Property(b => b.UserId);

        }
    }
}
