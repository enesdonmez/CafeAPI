using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Context;
using System.Diagnostics;

namespace CafeAPI.Persistence.Middleware
{
    public class SerilogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SerilogMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            var request = context.Request;
            var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
            var claim = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "_e")?.Value ?? "anonim";
            var userName = claim ?? "anonim";
            var requestPath = request.Path;

            using (LogContext.PushProperty("Username", userName))
            using (LogContext.PushProperty("RequestPath", requestPath))
            using (LogContext.PushProperty("RequestMethod", request.Method))
            using (LogContext.PushProperty("RequestIP", ipAddress))
            {
                Log.Information("Gelen istek: {Method} {Path} - IP:{IP}", request.Method, request.Path, ipAddress);

                try
                {
                    await _next(context);
                    sw.Stop();
                    Log.Information("Yanit: {StatusCode} - Sure: {Elapsed} ms", context.Response.StatusCode, sw.ElapsedMilliseconds);
                }
                catch (Exception ex)
                {
                    sw.Stop();
                    Log.Error(ex, "Hata oluştu: {Message} - IP:{IP} - Sure:{Elapsed}", ex.Message, ipAddress, sw.ElapsedMilliseconds);
                    throw;
                }
            }

        }
    }
}
