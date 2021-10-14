using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight.Api.Domain.Flights;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers.Flights
{
    [ApiController]
    [Route("api")]
    public class FlightsController : ControllerBase
    {
        private readonly ISender _sender;

        public FlightsController(ISender sender) => _sender = sender;

        [HttpGet("airports/{airport}/flights")]
        public async Task<ActionResult<IList<ApiFlight>>> GetFlightStatuses(string airport)
        {
            var flights = await _sender.Send(new GetFlightsByAirport(airport));
            return flights.Select(f => new ApiFlight(f)).ToList();
        }
    }
}
