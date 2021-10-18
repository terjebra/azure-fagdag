using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Flight.Api.Domain.Flights;
using Flight.Api.Domain.FlightSubscriptions.Commands;
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

        [HttpPost("airports/{airport}/flights/{flightId}/subscriptions")]
        public async Task<ActionResult<IList<ApiFlight>>> CreateSubscriptions(string airport, string flightId)
        {
            var oid = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier");

            if (oid == null)
            {
                return BadRequest();
            }

          
            await _sender.Send(new CreateFlightSubscription(oid.Value, flightId, airport));
            return Ok();
        }
    }
}
