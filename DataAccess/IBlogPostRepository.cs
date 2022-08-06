using BlogPostsManagementSystem.DataAccess.Models;

namespace BlogPostsManagementSystem.DataAccess
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAll();
        Task<BlogPost> GetById(int id);
    }
}
