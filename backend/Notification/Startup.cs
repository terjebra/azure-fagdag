using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification;
using Notification.Storage;
using Shared.Services.Avinor;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Notification
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ITableClient, AzureTableClient>();

            var config = builder
                .Services
                .BuildServiceProvider()
                .GetRequiredService<IConfiguration>();

            builder.Services.AddHttpClient<IAvinorApiClient, AvinorApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://flydata.avinor.no");
            });
        }
    }
}