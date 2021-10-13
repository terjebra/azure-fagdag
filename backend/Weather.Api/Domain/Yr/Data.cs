using System.Text.Json.Serialization;

namespace Weather.Api.Domain.Yr
{
    public class Data
    {
        public Instant Instant { get; set; }
        
        [JsonPropertyName("next_1_hours")]
        public ForecastNext NextHour { get; set; }
    }
}