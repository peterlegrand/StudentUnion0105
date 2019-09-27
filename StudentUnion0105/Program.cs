﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace StudentUnion0105
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IWebHost webHost = CreateWebHostBuilder(args).Build();



            await webHost.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
