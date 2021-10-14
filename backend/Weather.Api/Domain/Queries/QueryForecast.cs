using System;
using Weather.Api.Domain.Yr;

namespace Weather.Api.Domain.Queries
{
    public class QueryForecast
    {
        public QueryForecast(ForecastEntry forecastEntry)
        {
            Time = forecastEntry.Time;
            Pressure = forecastEntry.Data.Instant.Details.Pressure;
            WindFromDirection = forecastEntry.Data.Instant.Details.WindFromDirection;
            WindSpeed = forecastEntry.Data.Instant.Details.WindSpeed;
            AirTemperature = forecastEntry.Data.Instant.Details.AirTemperature;
            PrecipitationAmountNextHour = forecastEntry.Data.NextHour?.Details.PrecipitationAmount;
            MinPrecipitationAmountNextHour = forecastEntry.Data.NextHour?.Details.PrecipitationAmountMin;
            MaxPrecipitationAmountNextHour = forecastEntry.Data.NextHour?.Details.PrecipitationAmountMax;
            ProbabilityOfPrecipitation = forecastEntry.Data.NextHour?.Details.ProbabilityOfPrecipitation;
            ProbabilityOfThunder = forecastEntry.Data.NextHour?.Details.ProbabilityOfThunder;
            SymbolCodeNextHour = forecastEntry.Data.NextHour?.Summary.SymbolCode;
        }

        public DateTime Time { get; set; }
        public double Pressure { get; set; }
        public double WindFromDirection { get; set; }
        public double WindSpeed { get; set; }
        public double? PrecipitationAmountNextHour { get; set; }
        public double? MaxPrecipitationAmountNextHour { get; set; }
        public double? MinPrecipitationAmountNextHour { get; set; }
        public double? ProbabilityOfPrecipitation { get; set; }
        public double? ProbabilityOfThunder { get; set; }
        public string SymbolCodeNextHour { get; set; }
        public double AirTemperature { get; set; }
    }
}