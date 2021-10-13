using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flight.Api.Domain.Services.Avinor.Models;

namespace Flight.Api.Domain.Services.Avinor
{
    public interface IAvinorApiClient
    {
        Task<IList<Airport>> GetAirports();
        Task<IList<Airline>> GetAirlines();
        Task<IList<FlightStatus>> GetFlightStatuses();
        Task<IList<Models.Flight>> GetFlights(string airport, DateTime? lastUpdated = null);
    }
}