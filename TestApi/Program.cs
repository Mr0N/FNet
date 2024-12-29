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

        // Add services to the container.

        builder.Services.AddControllers();
      

        _app = builder.Build();
      
        _app.Use(async (context, next) =>
        {

            await next();
            int code = context.Response.StatusCode;
            if (code != 200)
            {

                await context.Response.WriteAsync("Not Found");
            }
            
            //  context.Response.Headers.Append("Content-Length", context.Response.ContentLength?.ToString());

        });

        // Configure the HTTP request pipeline.

        /// _app.UseAuthorization();

        _app.MapControllers();

        _app.Run(uri);


    }
}
