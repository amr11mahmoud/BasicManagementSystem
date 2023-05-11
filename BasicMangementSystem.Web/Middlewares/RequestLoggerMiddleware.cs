namespace BasicMangementSystem.Web.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly ILogger<RequestLoggerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(ILogger<RequestLoggerMiddleware> logger, RequestDelegate Next)
        {
            _logger = logger;
            _next = Next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            var start = DateTime.UtcNow;
            _logger.LogInformation($"Request Time:{context.Request.Path}, {(DateTime.UtcNow - start).ToString()}");
            await _next(context);
        }
    }

    public static class RequestLoggerExtentions
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
