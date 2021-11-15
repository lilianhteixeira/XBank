using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;
using XBank.Domain.Core.CustomExceptions;
using XBank.Service.API.Classes;

namespace XBank.Service.API.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException exc)
            {
                string result = new ErrorDetails()
                {
                    Message = exc.Message,
                    StatusCode = exc.Code,
                    Errors = exc.Errors
                    
                }.ToString();
                context.Response.StatusCode = exc.Code;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(result);
            }
        }
    }
}
