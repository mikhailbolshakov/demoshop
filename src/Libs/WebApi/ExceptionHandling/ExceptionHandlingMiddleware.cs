using DemoShop.Libs.WebApi.ExceptionHandling.CustomExceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DemoShop.Libs.WebApi.ExceptionHandling
{
    public class ExceptionHandlingMiddleware
    {

        // TODO: Logging

        private readonly RequestDelegate _method;

        private readonly Dictionary<Type, HttpStatusCode> _excMap = new Dictionary<Type, HttpStatusCode>();

        public ExceptionHandlingMiddleware(RequestDelegate method)
        {
            _method = method;

            _excMap.Add(typeof(DsValidationException), HttpStatusCode.BadRequest);
            _excMap.Add(typeof(DsNotFoundException), HttpStatusCode.NotFound);
            _excMap.Add(typeof(NotImplementedException), HttpStatusCode.NotImplemented);
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _method(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode statusCode;

            statusCode = _excMap.TryGetValue(exception.GetType(), out statusCode)
                ? statusCode
                : HttpStatusCode.InternalServerError;

            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(new WebApiExceptionDetails()
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = exception.Message,
                StackTrace = exception.StackTrace
            }.ToString());
        }

    }
}
