using BlogPostsManagementSystem.DataAccess;
using BlogPostsManagementSystem.DataAccess.Models;

namespace BlogPostsManagementSystem.GraphQL;

public class AuthorQuery
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorQuery(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<Author> GetAuthorByName(string name)
    {
        return await _authorRepository.GetByName(name);
    }
}