using BlogPostsManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsManagementSystem.DataAccess
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public BlogPostRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var _applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                _applicationDbContext.Database.EnsureCreated();
            }
        }

        public async Task<List<BlogPost>> GetAll()
        {
            using (var applicationDbContext = await _dbContextFactory.CreateDbContextAsync())
            {
                return await applicationDbContext.BlogPosts.ToListAsync();
            }
        }

        public async Task<BlogPost> GetById(int id)
        {
            using (var applicationDbContext = await _dbContextFactory.CreateDbContextAsync())
            {
                return await applicationDbContext.BlogPosts.SingleOrDefaultAsync(blogPost => blogPost.Id == id);
            }
        }
    }
}
