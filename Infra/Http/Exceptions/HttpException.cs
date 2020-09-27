using System;
using System.Net;

namespace CS201_WebApi.Infra.Http.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public HttpException(
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            string message = "An error occurred.", 
            Exception innerException = null) 
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }

    public class NotFoundException : HttpException
    {
        public NotFoundException(string message = "Not found.", Exception innerException = null)
            : base(HttpStatusCode.NotFound, message, innerException) {}
    }

    public class BadRequestException : HttpException
    {
        public BadRequestException(string message = "Invalid.", Exception innerException = null)
            : base(HttpStatusCode.BadRequest, message, innerException) { }
    }
}