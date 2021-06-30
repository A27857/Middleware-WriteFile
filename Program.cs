using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASPCORE
{
    public class Program
    {
        /*
        Host(IHost) ob:
        - Dependency injection (ID):IServiceProvider{ServiceConllection}
        - Logging   (IlLogging)
        - Configuration
        - IHostedService==>StartAsync :Run HTTP Server(Kestrel Http )
        1) IHost Builder
        2) Cau hinh, dang ky cac dich vu (goi ConfigureWebHostDefaults)
        3) IHostBuilder.Build()=>Host(IHost)
        4) Host.Run();
        Request==? pipeline (Middleware)
        */
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    
}
