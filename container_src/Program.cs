public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Tắt logging
        builder.Logging.SetMinimumLevel(LogLevel.Warning);

        var app = builder.Build();
        app.MapGet("/", async (ctx) =>
        {
            ctx.Response.ContentType = "application/json";
            ctx.Response.StatusCode = 200;
            await ctx.Response.WriteAsJsonAsync(new { status = ctx.Response.StatusCode, message = "Hello from Kourain .NET 8 Minimal API" });
        });

        app.MapGet("/status", async (ctx) =>
        {
            ctx.Response.ContentType = "application/json";
            ctx.Response.StatusCode = 200;
            await ctx.Response.WriteAsJsonAsync(new { status = ctx.Response.StatusCode, message = "API is running" });
        });

        app.MapGroup("/api")
            .MapGet("/", async (ctx) =>
            {
                await ctx.Response.WriteAsJsonAsync(new { status = "API is running" });
            });
        app.UseMiddleware<CloudflareContainerLogMiddleware>();
        app.Run();
    }
}