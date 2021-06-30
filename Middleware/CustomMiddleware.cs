using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace ASPCORE
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string folder = @"data\";
            string fileName = "data.txt";
            string fullPath = folder + fileName;
            // request http
            var scheme=(context.Request.Scheme+"://");
            var host=context.Request.Host;
            var path=context.Request.Path;
            var queryString=context.Request.QueryString;
            var body=context.Request.Body;
            string total = $" Scheme - {scheme} | Host - {host} | Path {path} | QueryString - {queryString} | Body - {body}";
            //write
            await File.WriteAllTextAsync(fullPath,total);
            // Read a file  
            string readText = File.ReadAllText(fullPath);
            Console.WriteLine(readText);
            await _next(context);
        }
    }
}