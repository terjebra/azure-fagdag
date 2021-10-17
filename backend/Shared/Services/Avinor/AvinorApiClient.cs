using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Extensions;
using Shared.Services.Avinor.Models;

namespace Shared.Services.Avinor
{
    public class AvinorApiClient : IAvinorApiClient
    {
        private readonly HttpClient  _client;

        public AvinorApiClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<IList<Airport>> GetAirports()
        {
            var responseMessage = await _client.GetAsync("airportNames.asp");
            var airPortList = await responseMessage.Deserialize<AirportRoot>();
            return airPortList.Airports;
        }
        public async Task<IList<Airline>> GetAirlines()
        {
            var responseMessage = await _client.GetAsync("airlineNames.asp");
            var airLineList = await responseMessage.Deserialize<AirlinesRoot>();
            return airLineList.Airlines;
        }
        public async Task<IList<FlightStatus>> GetFlightStatuses()
        {
            var responseMessage = await _client.GetAsync("flightStatuses.asp");
            var statusList = await responseMessage.Deserialize<FlightStatusRoot>();
            return statusList.Stautses;
        }

        public async Task<IList<Models.Flight>> GetFlights(string airport, DateTime? lastUpdated = null)
        {
            var requestUri = $"XmlFeed.asp?airport={airport.ToUpper()}";
            

            if (lastUpdated != null)
            {
                requestUri += $"&lastUpdate={lastUpdated.Value:s}";
            }
            var responseMessage = await _client.GetAsync(requestUri);
            var statusList = await responseMessage.Deserialize<AirportFlightsRoot>();
            return statusList.AirportFlights.Flights;
        }
    }
}