using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using DataLayer;

namespace ArtistSite
{
    public class Program
    {
        //The ASP.Net Project is
        //A Console App listening for Web Requests
        public static void Main(string[] args)
        {
            ////When the console app is run
            ////Create the host, builld the host and then run the host
            //CreateHostBuilder(args).Build().Run();
            ////Calling CreateHostBuilder
            ///
            var host = BuildWebHost(args);

            //var host = CreateHostBuilder(args).Build();

            if (args.Length == 1 && args[0].ToLower() == "/seed")
            {
                RunSeeding(host);
            }
            else
            {
                host.Run();
            }
        }

        private static void RunSeeding(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<ArtistSeeder>();
                seeder.SeedAsync().Wait();
            }

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
            .UseStartup<Startup>()
            .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx,
            IConfigurationBuilder builder)
        {
            builder.Sources.Clear();

            builder.AddJsonFile("config.json", false, true)
                .AddEnvironmentVariables();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(AddConfiguratio)
            //Create a default builder
                .ConfigureWebHostDefaults(webBuilder =>
                //Configure a web host
                {
                    webBuilder.UseStartup<Startup>();
                    //For the startup object, for knowing how to configure it
                    //Use a class called Stratup
                });

        private static void AddConfiguratio(HostBuilderContext ctx, 
            IConfigurationBuilder bldr)
        {
            bldr.Sources.Clear();

            bldr.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }
    }
}
