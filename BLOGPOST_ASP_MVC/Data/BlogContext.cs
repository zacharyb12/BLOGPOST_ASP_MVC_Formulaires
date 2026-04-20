using BLOGPOST_ASP_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BLOGPOST_ASP_MVC.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {}

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);
        }
    }
}