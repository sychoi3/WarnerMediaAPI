using System;
using System.Net;
using WarnerMedia.Domain;

namespace WarnerMedia.Middleware.Exceptions
{
    public class ApiException : Exception
    {
        public ErrorResponse ErrorResponse { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ApiException(HttpStatusCode statusCode, ErrorResponse errorResponse)
        {
            StatusCode = statusCode;
            ErrorResponse = errorResponse;
        }
    }
}
