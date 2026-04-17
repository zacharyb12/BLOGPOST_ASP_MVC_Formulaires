using Data;
using Models.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.BlogRepositories
{
    public class BlogRepository(BlogContext _context) : IBlogRepository
    {
        public async Task<bool> CreateBlogAsync(CreateBlog newBlog)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteBlogAsync(int id, Blog blog)
        {
            throw new NotImplementedException();
        }

        public async Task<Blog> GetBlogById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Blog>> GetBlogsAsync()
        {
            return  _context.Blogs.ToList();
        }

        public Task<bool> UpdateBlogAsync(UpdateBlog updatedBlog)
        {
            throw new NotImplementedException();
        }
    }
}
