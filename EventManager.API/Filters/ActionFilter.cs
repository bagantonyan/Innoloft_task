using EventManager.API.Models.ApiModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using EventManager.API.Extensions;
using Newtonsoft.Json;

namespace EventManager.API.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                if (context.HttpContext.Response.StatusCode.IsSuccess())
                {
                    var responseModel = ApiResponse<object>
                        .Success(objectResult.Value, context.HttpContext.Response.StatusCode);
                    objectResult.Value = responseModel;
                }
                else
                {
                    var responseModel = ApiResponse<object>
                        .Fail(JsonConvert.SerializeObject(context.HttpContext.Response.Body), context.HttpContext.Response.StatusCode);
                    objectResult.Value = responseModel;
                }
            }
        }
    }
}