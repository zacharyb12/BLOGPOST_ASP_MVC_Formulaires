using BLOGPOST_ASP_MVC.Models;

namespace BLOGPOST_ASP_MVC.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetBlogs();

        Task<Blog?> GetById(int id);

        Task<IEnumerable<Blog>> GetBlogByUser(int id);

        Task<bool> CreateBlog(CreateBlogDTOs newBlog);

        Task<bool> UpdateBlog(int id, UpdateBlogDTOs updatedBlog);

        Task<bool> DeleteBlog(int id);
    }
}
