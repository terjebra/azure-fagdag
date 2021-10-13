using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight.Api.Domain.Airlines.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers.Airlines
{
    [ApiController]
    [Route("api")]
    public class AirlineController : ControllerBase
    {
        private readonly ISender _sender;

        public AirlineController(ISender sender) => _sender = sender;

        [HttpGet("airlines")]
        public async Task<ActionResult<IList<ApiAirline>>> GetAirlines()
        {
            var airlines = await _sender.Send(new GetAirlines());
            return airlines.Select(a => new ApiAirline(a)).ToList();
        }
    }
}
