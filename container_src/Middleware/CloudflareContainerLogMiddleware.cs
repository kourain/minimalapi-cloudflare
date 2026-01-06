public class CloudflareContainerLogMiddleware
{
    private readonly RequestDelegate _next;
    public CloudflareContainerLogMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context, ILogger<CloudflareContainerLogMiddleware> logger)
    {
        DateTime requestTime = DateTime.UtcNow;
        context.Response.OnStarting(() =>
        {
            DateTime responseTime = DateTime.UtcNow;
            context.Response.Headers["X-API-Time-Milliseconds"] = (responseTime - requestTime).TotalMilliseconds.ToString();
            return Task.CompletedTask;
        });
        context.Response.OnCompleted(() =>
        {
            logger.LogWarning("Request Path: {Path}, status: {StatusCode}", context.Request.Path, context.Response.StatusCode);
            return Task.CompletedTask;
        });
        await _next(context);
    }
}