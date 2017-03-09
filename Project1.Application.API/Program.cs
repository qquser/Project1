using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Project1.Application.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = WebHost();
            host.Run();
        }

        public static IWebHost WebHost()
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                //.UseUrls("http://localhost:50001/")
                .UseApplicationInsights()
                .Build();
        }
    }
}
