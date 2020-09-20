using System;
using System.Net;
using CS201_WebApi.Infra.Http.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CS201_WebApi.Infra.Http
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpException httpException)
                ProcessError(context, httpException.StatusCode, httpException);
            else if (context.Exception is Exception exception)
                ProcessError(context, HttpStatusCode.InternalServerError, exception);
        }

        private void ProcessError(ActionExecutedContext context, HttpStatusCode statusCode, Exception exception)
        {
            context.Result = new JsonResult(new
            {
                StatusCode = statusCode,
                Message = exception.Message,
            })
            {
                StatusCode = (int)statusCode,
            };
            context.ExceptionHandled = true;
        }
    }
}