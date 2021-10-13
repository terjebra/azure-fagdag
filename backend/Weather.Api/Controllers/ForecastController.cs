using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Weather.Api.Domain.Queries;

namespace Weather.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ForecastController : ControllerBase
    {
        private readonly ISender _sender;

        public ForecastController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("forecast")]
        public async Task<ActionResult<IList<ApiForecast>>> GetForecast([FromQuery]double latitude, [FromQuery]double longitude)
        {
            var forecastData = await _sender.Send(new GetForecastByCoordinates(latitude, longitude));
            return forecastData.Select(x => new ApiForecast(x)).ToList();
        }
    }
}
