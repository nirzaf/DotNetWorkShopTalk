using ExampleGraphQL.Shared;

namespace ExampleGraphQL.Server.GraphQL;

public class Query
{
    public List<BlogPost> GetAllBlogPosts() => InMemoryDatasource.BlogPosts;

    public BlogPost GetBlogPost(Guid id)
    {
        return InMemoryDatasource.BlogPosts.Single(b => b.Id == id);
    }
}