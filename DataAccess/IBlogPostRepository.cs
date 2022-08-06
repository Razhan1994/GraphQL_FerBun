using BlogPostsManagementSystem.DataAccess.Models;

namespace BlogPostsManagementSystem.DataAccess
{
    public interface IBlogPostRepository
    {
        public Task<List<BlogPost>> GetAllAsync();
        public Task<BlogPost> GetByIdAsync(int id);
    }
}
