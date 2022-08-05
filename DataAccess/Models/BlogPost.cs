namespace BlogPostsManagementSystem.DataAccess.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [GraphQLNonNullType]
        public string Title { get; set; }
        [GraphQLNonNullType]
        public int AuthorId { get; set; }
    }
}
