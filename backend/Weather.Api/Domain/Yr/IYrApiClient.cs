using System.Threading.Tasks;

namespace Weather.Api.Domain.Yr
{
    public interface IYrApiClient
    {
        Task<Forecast> GetForecast(double latitude, double longitude);
    }
}