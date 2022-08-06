using BlogPostsManagementSystem.DataAccess.Models;

namespace BlogPostsManagementSystem.DataAccess
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task<Author> CreateAuthorAsync(Author author);
    }
}
