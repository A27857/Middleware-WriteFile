using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.Web;

public class CustomStartup
{
    //SignUp Services
    public void ConfigureServices(IServiceCollection services)
    {

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseStaticFiles();
        //add statuscodepage to pipeline if 
        app.UseStatusCodePages();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async (context) =>
            {
                await context.Response.WriteAsync("Home");
            });
            endpoints.MapGet("/about", async (context) =>
             {
                 await context.Response.WriteAsync("Page About");
             });
            endpoints.MapGet("/contact", async (context) =>
            {
                await context.Response.WriteAsync("Page Contact");
            });
        });

        app.Map("/abc", app1 =>
        {
            app1.Run(async (context) =>
            {
                await context.Response.WriteAsync("This is middleware!");
            });
        });
        

    }
}