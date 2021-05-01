using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RealStateSolution.API
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
        {
            ObjectResult errorResponse;

            try
            {
                await _next(context);
                return;
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "An unhandled error occurred");

                errorResponse = new ObjectResult(new
                {
                    timestamp = DateTimeOffset.UtcNow.ToString("s"),
                });
            }

            var result = JsonSerializer.Serialize(errorResponse.Value);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorResponse.StatusCode ?? (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(result);
        }
    }
}
