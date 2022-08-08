using BlogPostsManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                _applicationDbContext.Database
                    .EnsureCreated();
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
                return await applicationDbContext.Authors.SingleOrDefaultAsync(x => x.Id == id);
            }
        }
        public async Task<List<Author>> GetByIdsAsync(List<int> ids)
        {
            using (var applicationDbContext = await _dbContextFactory.CreateDbContextAsync())
            {
                return await applicationDbContext.Authors.Where(x => ids.Contains(x.Id)).ToListAsync();
            }
        }
        public async Task<Author> CreateAuthorAsync(Author author)
        {
            using (var applicationDbContext = await _dbContextFactory.CreateDbContextAsync())
            {
                await applicationDbContext.Authors.AddAsync(author);
                await applicationDbContext.SaveChangesAsync();

                return author;
            }
        }

        public async Task<Author> GetByName(string name)
        {
            using (var applicationDbContext = await _dbContextFactory.CreateDbContextAsync())
            {
                var author = await applicationDbContext.Authors.FirstOrDefaultAsync(x =>
                    x.FirstName.Contains(name) || x.LastName.Contains(name));

                return author;
            }
        }
    }
}