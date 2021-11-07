using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WarnerMedia.Domain;
using WarnerMedia.Middleware.Exceptions;

namespace WarnerMedia.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            //catch (BadRequestException ex)
            //{
            //    await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message, ex.ErrorData);
            //}
            //catch (ForbiddenException ex)
            //{
            //    await HandleExceptionAsync(context, HttpStatusCode.Forbidden, ex.Message, null);
            //}
            //catch (NotFoundException ex)
            //{
            //    await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message, null);
            //}
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred. Message: {ex.Message}, stack trace: {ex.StackTrace}");
                context.Response.ContentType = "application/json";
                ErrorResponse errorResponse;

                if (ex is ApiException apiException)
                {
                    context.Response.StatusCode = (int)apiException.StatusCode;
                    errorResponse = apiException.ErrorResponse;
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse = ErrorResponse.InternalServerErrorResponse;
                }

                var serializedResponse = JsonSerializer.Serialize(errorResponse);
                _logger.LogError(($"Error response body: {serializedResponse}"));

                await context.Response.WriteAsync(serializedResponse);
            }
        }

        //private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message, object errorData)
        //{
        //    var code = (int)statusCode;

        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = code;
        //    var r = ReasonPhrases.GetReasonPhrase(code);

        //    var errorResult = JsonSerializer.Serialize(new Response<object>()
        //    {
        //        errors = errorData,
        //        //Error = new Error
        //        //{
        //        //    Code = r,
        //        //    Message = $"{message}",
        //        //    Errors = errorData
        //        //}
        //    });
        //    return context.Response.WriteAsync(errorResult);
        //}
    }
}
