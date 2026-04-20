using BLOGPOST_ASP_MVC.Data;
using BLOGPOST_ASP_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace BLOGPOST_ASP_MVC.Repositories
{
    public class BlogRepository(BlogContext _context) : IBlogRepository
    {
        public async Task<bool> CreateBlog(CreateBlogDTOs newBlog)
        {
            Blog blogToAdd = new()
            {
                Title = newBlog.Title,
                Content = newBlog.Content,
                IsVisible = newBlog.IsVisible,
                UserId = "1"
            };

            await _context.AddAsync(blogToAdd);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }
        public async Task<Blog?> GetById(int id)
        {
            Blog? blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if(blog == null)
            {
                return null;
            }
            return blog;
        }
        public async Task<bool> UpdateBlog(int id, UpdateBlogDTOs updatedBlog)
        {
            Blog? blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if(blog == null)
            {
                return false;
            }

            blog.Title = updatedBlog.Title;
            blog.Content = updatedBlog.Content;
            blog.IsVisible = updatedBlog.IsVisible;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteBlog(int id)
        {
            Blog? blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if(blog == null)
            {
                return false;
            }
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return true;
        }


        public Task<IEnumerable<Blog>> GetBlogByUser(int id)
        {
            throw new NotImplementedException();
        }


    }
}
