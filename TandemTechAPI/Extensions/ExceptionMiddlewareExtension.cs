using Repository.Contracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace TandemTechAPI.Extensions
{
    public class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var errorDetails = new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. Please try again later."
                        };
                        await context.Response.WriteAsync(errorDetails.ToString());
                    }
                });
            });
        }
    }
}
