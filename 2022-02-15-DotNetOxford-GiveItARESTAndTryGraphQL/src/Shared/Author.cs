namespace ExampleGraphQL.Shared;

public record Author
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; }
}