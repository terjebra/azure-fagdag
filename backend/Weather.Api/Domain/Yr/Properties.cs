using System.Collections.Generic;

namespace Weather.Api.Domain.Yr
{
    public class Properties
    {
        public IList<ForecastEntry> TimeSeries { get; set; }
    }
}