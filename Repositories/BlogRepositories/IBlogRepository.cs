using Models.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.BlogRepositories
{
    public interface IBlogRepository
    {
        Task<bool> CreateBlogAsync(CreateBlog newBlog);

        Task<bool> UpdateBlogAsync(UpdateBlog updatedBlog);

        Task<List<Blog>> GetBlogsAsync();

        Task<Blog> GetBlogById(int id);

        Task<bool> DeleteBlogAsync(int id,Blog blog);
    }
}
