// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Tắt logging
builder.Logging.SetMinimumLevel(LogLevel.Critical);

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

app.MapGroup("/databin")
    .AddEndpointFilter(async (context, next) =>
    {
        // Example filter logic: Log the request path
        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogCritical("Request path: {Path}", context.HttpContext.Request.Path);
        return await next(context);
    })
    .MapGet("/", async (ctx) =>
    {
        await ctx.Response.WriteAsJsonAsync(new { status = "API is running" });
    });
app.Run();