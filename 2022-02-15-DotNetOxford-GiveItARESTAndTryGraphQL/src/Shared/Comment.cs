namespace ExampleGraphQL.Shared;

public class Comment
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
    public Guid BlogPostId { get; set; }
    public BlogPost BlogPost { get; set; }
    public string Message { get; set; }
}