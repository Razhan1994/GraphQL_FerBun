using BlogPostsManagementSystem.DataAccess.Models;

namespace BlogPostsManagementSystem.DTO
{
    public class BlogAuthor
    {
        public Author Author { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
