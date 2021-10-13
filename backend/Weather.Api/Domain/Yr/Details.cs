using System.Text.Json.Serialization;

namespace Weather.Api.Domain.Yr
{
    public class Details
    {
        [JsonPropertyName("precipitation_amount")]
        public double PrecipitationAmount { get; set; }
        [JsonPropertyName("precipitation_amount_max")]
        public double PrecipitationAmountMax { get; set; }
        [JsonPropertyName("precipitation_amount_min")]
        public double PrecipitationAmountMin { get; set; }
        [JsonPropertyName("probability_of_precipitation")]
        public double ProbabilityOfPrecipitation { get; set; }
        [JsonPropertyName("probability_of_thunder")]
        public double ProbabilityOfThunder { get; set; }
    }
}