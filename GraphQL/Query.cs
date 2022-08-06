using BlogPostsManagementSystem.DataAccess;
using BlogPostsManagementSystem.DataAccess.Models;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPostsManagementSystem.DTO;

namespace BlogPostsManagementSystem.GraphQL
{
    public class Query
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ITopicEventSender _eventSender;

        public Query(IAuthorRepository authorRepository,
            IBlogPostRepository blogPostRepository,
            ITopicEventSender eventSender)
        {
            _authorRepository = authorRepository;
            _blogPostRepository = blogPostRepository;
            _eventSender = eventSender;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            List<Author> authors = await _authorRepository.GetAllAsync();
            await _eventSender.SendAsync("ReturnedAuthors",
                authors);
            return authors;
        }
        public async Task<Author> GetAuthorById(int id)
        {
            Author author = await _authorRepository.GetByIdAsync(id);
            await _eventSender.SendAsync("ReturnedAuthor", author);

            return author;
        }
        public async Task<List<BlogPost>> GetAllBlogPosts()
        {
            List<BlogPost> blogPosts = await _blogPostRepository.GetAllAsync();
            await _eventSender.SendAsync("ReturnedBlogPosts", blogPosts);

            return blogPosts;
        }
        public async Task<BlogPost> GetBlogPostById(int id)
        {
            BlogPost blogPost = await _blogPostRepository.GetByIdAsync(id);
            await _eventSender.SendAsync("ReturnedBlogPost", blogPost);

            return blogPost;
        }

        public async Task<List<BlogAuthor>> GetBlogsWithAuthor()
        {
            var blogPosts = await _blogPostRepository.GetAllAsync();
            var authors = await _authorRepository.GetByIdsAsync(blogPosts.Select(x => x.AuthorId).ToList());

            return blogPosts.Select(x => new BlogAuthor()
            {
                BlogPost = x,
                Author = authors.FirstOrDefault(c => c.Id == x.AuthorId)
            })
                .ToList();
        }
    }
}