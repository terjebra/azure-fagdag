using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Services.Avinor.Models;

namespace Shared.Services.Avinor
{
    public interface IAvinorApiClient
    {
        Task<IList<Airport>> GetAirports();
        Task<IList<Airline>> GetAirlines();
        Task<IList<FlightStatus>> GetFlightStatuses();
        Task<IList<Models.Flight>> GetFlights(string airport, DateTime? lastUpdated = null);
    }
}