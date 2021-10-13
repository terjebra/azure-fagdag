using System;
using Weather.Api.Domain.Queries;

namespace Weather.Api.Controllers
{
    public class ApiForecast
    {
        public ApiForecast(QueryForecast forecast)
        {
            Time = forecast.Time;
            Pressure = forecast.Pressure;
            WindFromDirection = forecast.WindFromDirection;
            WindSpeed = forecast.WindSpeed;
            PrecipitationAmountNextHour = forecast.PrecipitationAmountNextHour;
            MaxPrecipitationAmountNextHour = forecast.MaxPrecipitationAmountNextHour;
            MinPrecipitationAmountNextHour = forecast.MinPrecipitationAmountNextHour;
            SymbolCodeNextHour = forecast.SymbolCodeNextHour;
            AirTemperature = forecast.AirTemperature;
        }

        public DateTime Time { get; set; }
        public double Pressure { get; set; }
        public double WindFromDirection { get; set; }
        public double WindSpeed { get; set; }
        public double? PrecipitationAmountNextHour { get; set; }
        public double? MaxPrecipitationAmountNextHour { get; set; }
        public double? MinPrecipitationAmountNextHour { get; set; }
        public string SymbolCodeNextHour { get; set; }
        public double AirTemperature { get; set; }
    }
}
