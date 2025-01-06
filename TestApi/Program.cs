using TestApi.Controllers;

new TestServer().Run("http://localhost:5102");

public class TestServer : IDisposable
{
    public void Dispose()
    {
        _app.DisposeAsync().GetAwaiter().GetResult();
    }
    WebApplication _app;
    public void Run(string uri)
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = false; 
            options.LowercaseQueryStrings = false; 
            options.AppendTrailingSlash = false; 
        });
        // Add services to the container.

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(HomeController).Assembly);


        _app = builder.Build();

        _app.MapControllers();
        _app.Use(async (context, next) =>
        {

            await next();
            int code = context.Response.StatusCode;
            if (code != 200)
            {

                await context.Response.WriteAsync("Not Found1111111111111111111111111111111111111111111111");
                //await context.Response.WriteAsJsonAsync(new {qqq="9043903490"});
                await context.Response.WriteAsync("Not Found");
                await context.Response.WriteAsync("Not Found");
                await context.Response.WriteAsync("Not Found");
                await context.Response.WriteAsync("Not Found");
            }
            
            //context.Response.Headers.Append("Content-Length", context.Response.ContentLength?.ToString());

        });

        // Configure the HTTP request pipeline.

        /// _app.UseAuthorization();

        _app.MapGet("/routes", (HttpContext httpContext) =>
        {
            var endpoints = httpContext.RequestServices.GetRequiredService<EndpointDataSource>();

            var routeList = endpoints.Endpoints
                .OfType<RouteEndpoint>()
                .Select(endpoint => new
                {
                    RoutePattern = endpoint.RoutePattern.RawText,
                    HttpMethods = endpoint.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods ?? new List<string> { "ANY" }
                })
                .ToList();

            return Results.Ok(routeList);
        });
        _app.Run(uri);


    }
}
