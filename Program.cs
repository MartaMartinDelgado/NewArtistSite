using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite
{
    public class Program
    {
        //The ASP.Net Project is
        //A Console App listening for Web Requests
        public static void Main(string[] args)
        {
            //When the console app is run
            //Create the host, builld the host and then run the host
            CreateHostBuilder(args).Build().Run();
            //Calling CreateHostBuilder
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //Create a default builder
                .ConfigureWebHostDefaults(webBuilder =>
                //Configure a web host
                {
                    webBuilder.UseStartup<Startup>();
                    //For the startup object, for knowing how to configure it
                    //Use a class called Stratup
                });
    }
}
