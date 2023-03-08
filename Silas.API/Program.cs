using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silas.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
           .ConfigureLogging((hostingContext, logging) =>
           {
               logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
               logging.ClearProviders();
               logging.AddDebug();
               logging.AddConsole();
               logging.AddEventSourceLogger();
               logging.AddTraceSource("Information, ActivityTracing"); // Add Trace listener provider

           })
        //.UseUrls("https://*:9999")
        .UseStartup<Startup>();
    }
}
