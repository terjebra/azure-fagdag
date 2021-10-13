using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Notification;
using Notification.Storage;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Notification
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ITableClient, AzureTableClient>();
        }
    }
}