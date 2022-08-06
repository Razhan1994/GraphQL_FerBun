using BlogPostsManagementSystem.DataAccess;
using BlogPostsManagementSystem.DataAccess.Models;
using HotChocolate;
using HotChocolate.Resolvers;
using System.Linq;
namespace BlogPostsManagementSystem.GraphQL
{
    public class AuthorResolver
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorResolver([Service] IAuthorRepository authorService)
        {
            _authorRepository = authorService;
        }
        public async Task<Author> GetAuthor(BlogPost blog, IResolverContext ctx)
        {
            var authors = await _authorRepository.GetAllAsync(); 
            return authors.Where(a => a.Id == blog.AuthorId).FirstOrDefault();
        }
    }
}