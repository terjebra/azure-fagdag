using Flight.Api.Domain.Airports.Queries;

namespace Flight.Api.Controllers.Airports
{
    public class ApiAirport
    {
        public ApiAirport(QueryAirport airport)
        {
            Code = airport.Code;
            Name = airport.Name;
        }

        public string Code { get; set; }
        public string Name { get; set; }
    }
}
