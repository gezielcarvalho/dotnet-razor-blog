namespace dotnet_razor_blog.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid BlogPostId { get; set; }
    }
}
