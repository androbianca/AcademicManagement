using BusinessLogic.Abstractions;
using BusinessLogic.Implementations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Ninject;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace Service
{
    public class Program
    {

        public static void Main(string[] args)
        {      
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
