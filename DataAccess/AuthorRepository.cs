using BlogPostsManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsManagementSystem.DataAccess
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public AuthorRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var _applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                _applicationDbContext.Database.EnsureCreated();
            }
        }

        public async Task<List<Author>> GetAllAsync()
        {
            using (var applicationDbContext = await _dbContextFactory.CreateDbContextAsync())
            {
                return await applicationDbContext.Authors.ToListAsync();
            }
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            using (var applicationDbContext = await _dbContextFactory.CreateDbContextAsync())
            {
                return await applicationDbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                await applicationDbContext.Authors.AddAsync(author);
                await applicationDbContext.SaveChangesAsync();

                return author;
            }
        }
    }
}
