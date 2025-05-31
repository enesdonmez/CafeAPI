using Microsoft.AspNetCore.Http;
using Serilog;
using System.Diagnostics;

namespace CafeAPI.Persistence.Middleware
{
    public class SerilogMiddleware
    {
        private readonly RequestDelegate _next;

        public SerilogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            var request = context.Request;
            var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
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
