using System;
using Azure.Identity;
using Flight.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Avinor.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                { 
                    var builtConfig = config.Build();
                    config.AddAzureKeyVault(new Uri(builtConfig.GetValue<string>("KeyVaultUrl")),
                        new DefaultAzureCredential());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
