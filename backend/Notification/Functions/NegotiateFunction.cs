using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Primitives;

namespace Notification.Functions
{
    public static class NegotiateFunction
    {
        private  static string UserIdHeader = "x-user-id";
            
        [FunctionName("negotiate")]
        public static async Task<SignalRConnectionInfo> GetSignalRInfo([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "{hubName}/negotiate")]
            HttpRequest request, string hubName, IBinder binder)
        {
            var attribute = new SignalRConnectionInfoAttribute { HubName = hubName, UserId = GetUserId(request.Headers) };
            var connectionInfo = binder.BindAsync<SignalRConnectionInfo>(attribute);
            return await connectionInfo;
        }

        public static StringValues GetUserId(IHeaderDictionary headerDictionary)
        {
            headerDictionary.TryGetValue(UserIdHeader, out var value);
            return value;
        }
    }
}
