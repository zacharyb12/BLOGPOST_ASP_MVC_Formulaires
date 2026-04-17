using Microsoft.EntityFrameworkCore;
using Models.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);
        }

    }
}
