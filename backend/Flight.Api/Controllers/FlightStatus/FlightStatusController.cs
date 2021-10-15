using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight.Api.Controllers.Flights;
using Flight.Api.Domain.FlightStatuses.Queries;
using Flight.Api.Domain.FlightSubscriptions.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers.FlightStatus
{
    [ApiController]
    [Route("api")]
    public class FlightStatusController : ControllerBase
    {
        private readonly ISender _sender;

        public FlightStatusController(ISender sender) => _sender = sender;

        [HttpGet("flight-statuses")]
        public async Task<ActionResult<IList<ApiFlightStatus>>> GetFlightStatuses()
        {
            var statuses = await _sender.Send(new GetFlightStatuses());
            return statuses.Select(a => new ApiFlightStatus(a)).ToList();
        }

        [HttpPost("airports/{airport}/flights/{flightId}/subscriptions")]
        public async Task<ActionResult<IList<ApiFlight>>> CreateSubscriptions(string airport, string flightId)
        {
            var userId = Request.Headers["x-user-id"].ToString();
            await _sender.Send(new CreateFlightSubscription(userId, flightId, airport));
            return Ok();
        }
    }
}
