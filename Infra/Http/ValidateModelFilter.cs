using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CS201_WebApi.Infra.Http
{
    public class ValidateModelFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 1;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                var statusCode = HttpStatusCode.BadRequest;
                var json = new
                {
                    StatusCode = statusCode,
                    Message = "Data is invalid.",
                    State = context.ModelState.ValidationState,
                };

                context.Result = new JsonResult(json)
                {
                    StatusCode = (int)statusCode,
                };
            }
        }
    }
}