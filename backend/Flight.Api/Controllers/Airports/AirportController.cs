using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight.Api.Domain.Airports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers.Airports
{
    [ApiController]
    [Route("api")]
    public class AirportController : ControllerBase
    {
        private readonly ISender _sender;

        public AirportController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("airports")]
        public async Task<ActionResult<IList<ApiAirport>>> GetAirports()
        {
            var airports = await _sender.Send(new GetAirports());
            var distinctAirports = airports.GroupBy(x => x.Name).Select(x => x.FirstOrDefault());
            return distinctAirports.Select(a => new ApiAirport(a)).ToList();
        }
    }
}
