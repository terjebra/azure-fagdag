using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Weather.Api.Domain.Yr
{
    public class YrApiClient : IYrApiClient
    {
        private readonly HttpClient _client;

        public YrApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<Forecast> GetForecast(double latitude, double longitude)
        {
            return await _client.GetFromJsonAsync<Forecast>($"weatherapi/locationforecast/2.0/complete?lat={latitude.ToString(CultureInfo.InvariantCulture)}&lon={longitude.ToString(CultureInfo.InvariantCulture)}");
        }
        
    }
}