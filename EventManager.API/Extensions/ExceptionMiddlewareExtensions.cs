using EventManager.API.Models.ApiModels;
using EventManager.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace EventManager.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(
                                ApiResponse<object>.Fail(
                                    contextFeature.Error.Message, 
                                    context.Response.StatusCode)));
                    }
                });
            });
        }
    }
}