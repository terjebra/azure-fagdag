using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Notification.Storage
{
    public class AzureTableClient : ITableClient
    {
        private readonly CloudTableClient _tableClient;
       
        public AzureTableClient(IConfiguration configuration)
        {
            var storageAccount = CloudStorageAccount.Parse(configuration.GetValue<string>("AzureWebJobsStorage"));
            _tableClient = storageAccount.CreateCloudTableClient();
        }
        
        public async Task<CloudTable> GetTableReference(TableReference tableReference)
        {
            var table =  _tableClient.GetTableReference(tableReference.TableName);
            await table.CreateIfNotExistsAsync();
            return table;
        }
    }

    public interface ITableClient
    {
        public Task<CloudTable> GetTableReference(TableReference tableReference);
    }
}