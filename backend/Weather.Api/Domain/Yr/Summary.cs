using System.Text.Json.Serialization;

namespace Weather.Api.Domain.Yr
{
    public class Summary
    {
        [JsonPropertyName("symbol_code")]
        public string SymbolCode { get; set; }
    }
}