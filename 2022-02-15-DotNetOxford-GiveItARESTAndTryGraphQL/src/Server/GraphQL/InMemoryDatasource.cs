using ExampleGraphQL.Shared;

namespace ExampleGraphQL.Server.GraphQL;

public static class InMemoryDatasource
{
    public static readonly Author Author = new()
    {
        Id = Guid.NewGuid(),
        Name = "Scott Sauber"
    };

    public static readonly BlogPost BlogPost = new()
    {
        Content = "GraphQL is the best",
        Id = Guid.Parse("51acb538-4262-4bce-b6a1-6575626c4645"),
        Title = "Give it a REST and Try GraphQL",
        Author = Author,
        AuthorId = Author.Id,
    };

    public static readonly List<BlogPost> BlogPosts = new()
    {
        BlogPost
    };
}