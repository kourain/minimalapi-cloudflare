// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (ctx) =>
{
    ctx.Response.ContentType = "application/json";
    ctx.Response.StatusCode = 200;
    await ctx.Response.WriteAsJsonAsync(new { status = "Ok", message = "Hello from Kourain .NET 8 Minimal API" });
});

app.MapGet("/status", async (ctx) =>
{
    ctx.Response.ContentType = "application/json";
    ctx.Response.StatusCode = 200;
    await ctx.Response.WriteAsJsonAsync(new { status = "API is running" });
});

app.MapGroup("/databin")
   .MapGet("/status", async (ctx) =>
   {
       await ctx.Response.WriteAsJsonAsync(new { status = "API is running" });
   });
app.Run();