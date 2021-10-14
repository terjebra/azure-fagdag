using System;

namespace Weather.Api.Domain.Yr
{
    public class ForecastEntry
    {
        public DateTime Time { get; set; }
        public Data Data { get; set; }
    }
}