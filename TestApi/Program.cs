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

        // Configure the HTTP request pipeline.

        _app.UseAuthorization();

        _app.MapControllers();

        _app.Run(uri);


    }
}