using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CS201_WebApi.Infra.Logging
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            var displayName = context?.GetEndpoint()?.DisplayName ?? "RequestLogging";
            var logger = _loggerFactory.CreateLogger(displayName);
            var method =  context.Request.Method;
            var url = context.Request.Path.Value;
            var originalBody = context.Response.Body;
            string responseBody = "";

            try
            {
                using (var memStream = new MemoryStream()) 
                {
                    context.Response.Body = memStream;

                    logger.LogInformation($"Request {method} {url}");

                    await _next(context);

                    // Rewind memory stream
                    memStream.Position = 0;
                    // Read stream as a string
                    responseBody = new StreamReader(memStream).ReadToEnd();

                    // Rewind memory stream
                    memStream.Position = 0;
                    // Copy memory stream to original stream
                    await memStream.CopyToAsync(originalBody);
                }
            }
            finally
            {
                var statusCode = context.Response?.StatusCode;
                
                logger.LogInformation($"Request {method} {url} => {statusCode} : {responseBody}");
                
                context.Response.Body = originalBody;
            }
        }
    }
}