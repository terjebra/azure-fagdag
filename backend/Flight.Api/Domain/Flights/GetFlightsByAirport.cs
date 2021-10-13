using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.Services.Avinor;

namespace Flight.Api.Domain.Flights
{
    public class GetFlightsByAirport : IRequest<IList<QueryFlight>>
    {
        public string Airport { get; }
        public DateTime? LastUpdated { get; }

        public GetFlightsByAirport(string airport, DateTime? lastUpdated = null)
        {
            Airport = airport;
            LastUpdated = lastUpdated;
        }
        public class Handler : IRequestHandler<GetFlightsByAirport, IList<QueryFlight>>
        {
            private readonly IAvinorApiClient _avinorApiClient;

            public Handler(IAvinorApiClient avinorApiClient)
            {
                _avinorApiClient = avinorApiClient;
            }
            public async Task<IList<QueryFlight>> Handle(GetFlightsByAirport request, CancellationToken cancellationToken)
            {
                var flights = await _avinorApiClient.GetFlights(request.Airport, request.LastUpdated);

                return flights.Select(x => new QueryFlight
                {
                    Airport = x.Airport,
                    Airline = x.Airline,
                    Direction = x.ArrivalDeparture.Equals("A") ? Direction.Arrival : Direction.Departure,
                    CheckIn = x.CheckIn,
                    Delayed = !string.IsNullOrWhiteSpace(x.Delayed) && x.Delayed.Equals("Y"),
                    Travel = x.DomesticInternational.Equals("D") ? Travel.Domestic :Travel.International,
                    FlightId = x.FlightId,
                    Gate = x.Gate,
                    Id = x.Id,
                    ScheduleTime = x.ScheduleTime,
                    StatusCode = x.Status?.Code,
                    StatusTime = x.Status?.Time,
                    ViaAirport = x.ViaAirport
                }).ToList();
;            }
        }
    }
}
