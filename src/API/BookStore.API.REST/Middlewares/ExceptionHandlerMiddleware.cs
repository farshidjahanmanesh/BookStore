using BookStore.API.REST.Models;
using BookStore.Core.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookStore.API.REST.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception ex)
        {
            var httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var response = new RestErrorResponse();
            response.URL = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
            response.Method = context.Request.Method;
            switch (ex)
            {
                case ValidationException vException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    response.ValidationErrors = vException.ValidationErrors;
                    break;
                case BadRequestException brException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    response.ValidationErrors.Add(brException.Message);
                    break;
                case Exception eException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    response.ValidationErrors.Add(eException.Message);
                    break;
            }
            context.Response.StatusCode = (int)httpStatusCode;
            var result = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(result);
        }
    }
}
