using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
namespace ASPCORE
{
    //test Mddleware
    public class ConsoleMiddleware
    {
        private readonly RequestDelegate _next;
        public ConsoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context){
            Console.Write(context.Request.Scheme+"://");
            Console.Write(context.Request.Host);
            Console.Write(context.Request.Path);
            Console.Write(context.Request.QueryString);
            Console.Write(context.Request.Body);
            await _next(context);
        }
}
}
