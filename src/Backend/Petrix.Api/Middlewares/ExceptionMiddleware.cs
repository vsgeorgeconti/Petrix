using Petrix.Application.Common;
using Petrix.Domain.Exceptions;

namespace Petrix.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                int statusCode;
                string code;

                if (ex is ValidationException)
                {
                    statusCode = 400;
                    code = "VALIDATION_ERROR";
                }
                else if (ex is ConflictException)
                {
                    statusCode = 409;
                    code = "CONFLICT";
                }
                else
                {
                    statusCode = 500;
                    code = "INTERNAL_SERVER_ERROR";
                }

                var message = statusCode == 500
                ? "Erro interno."
                : ex.Message;

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                var response = new ApiResponse<object>(false, code, null, message);
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}