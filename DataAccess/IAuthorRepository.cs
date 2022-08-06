using BlogPostsManagementSystem.DataAccess.Models;

namespace BlogPostsManagementSystem.DataAccess
{
    public interface IAuthorRepository
    {
        public Task<List<Author>> GetAllAsync();
        public Task<Author> GetByIdAsync(int id);
        public Task<List<Author>> GetByIdsAsync(List<int> ids);
        public Task<Author> CreateAuthorAsync(Author author);
    }
}
