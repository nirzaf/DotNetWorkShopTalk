namespace ExampleGraphQL.Shared;

public record BlogPost
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; init; } = "";
    public string Content { get; init; } = "";
    public Guid AuthorId { get; init; } = Guid.Empty;
    public Author Author { get; init; } = new();
}