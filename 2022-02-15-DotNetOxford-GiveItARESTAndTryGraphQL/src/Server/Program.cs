using ExampleGraphQL.Server.GraphQL;
using HotChocolate.Execution;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

ConfigureServices(webApplicationBuilder);

Configure(webApplicationBuilder);

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddRazorPages();
    builder.Services.AddGraphQLServer()
        .ModifyOptions(options =>
        {
            options.DefaultResolverStrategy = ExecutionStrategy.Serial;
        })
        .AddQueryType<Query>();
}

void Configure(WebApplicationBuilder builder)
{
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.MapGraphQL();
    
    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();
    
    app.UseRouting();
    
    
    app.MapControllers();
    app.MapFallbackToFile("index.html");

    app.Run();
}
