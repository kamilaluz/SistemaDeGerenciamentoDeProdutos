using GerenciamentoDeProdutos.Exceptions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace GerenciamentoDeProdutos.Middlewares
{
    public class ErrorHandingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            } catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = (int)HttpStatusCode.InternalServerError;

            if (exception is StatusCodeException statusCodeException)
            {
                code = statusCodeException.StatusCode;
            }

            var result = System.Text.Json.JsonSerializer.Serialize(new { message = exception.Message, StatusCode = code });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);

        }
    }
}
