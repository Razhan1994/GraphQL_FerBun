using BlogPostsManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsManagementSystem.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Author author1 = new Author()
            {
                Id = 1,
                FirstName = "Will",
                LastName = "Smith"
            };
            Author author2 = new Author()
            {
                Id = 2,
                FirstName = "Cristian",
                LastName = "Anderson"
            };
            Author author3 = new Author()
            {
                Id = 3,
                FirstName = "Sipan",
                LastName = "Xelat"
            };
            modelBuilder.Entity<Author>().HasData(author1, author2, author3);
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost()
                {
                    Id = 1,
                    Title = "Programming",
                    AuthorId = 1
                },
                new BlogPost()
                {
                    Id = 2,
                    Title = "Physic",
                    AuthorId = 2
                },
                new BlogPost()
                {
                    Id = 3,
                    Title = "Philosophy",
                    AuthorId = 3
                },
                new BlogPost
                {
                    Id = 4,
                    Title = "Introducing Machine Learning",
                    AuthorId = 2
                },
                new BlogPost
                {
                    Id = 5,
                    Title = "Introducing DevSecOps",
                    AuthorId = 3
                }
            );
        }
    }
}
