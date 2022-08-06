using BlogPostsManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace BlogPostsManagementSystem.DataAccess
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly IDbContextFactory
            <ApplicationDbContext> _dbContextFactory;
        public BlogPostRepository(IDbContextFactory
            <ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var applicationDbContext =
                   _dbContextFactory.CreateDbContext())
            {
                applicationDbContext.Database
                    .EnsureCreated();
            }
        }
        public async Task<List<BlogPost>> GetAllAsync()
        {
            using (var applicationDbContext = await _dbContextFactory.CreateDbContextAsync())
            {
                return await applicationDbContext.BlogPosts.ToListAsync();
            }
        }
        public async Task<BlogPost> GetByIdAsync(int id)
        {
            using (var applicationDbContext = await _dbContextFactory.CreateDbContextAsync())
            {
                return await applicationDbContext.BlogPosts.SingleOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}