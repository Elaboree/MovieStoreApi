using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using MovieStoreApi.Models.Core;
using System.Threading.Tasks;

namespace MovieStoreApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse { IsSucceeded = false, ErrorMessage = ex.Message }));
            }
        }
    }
}