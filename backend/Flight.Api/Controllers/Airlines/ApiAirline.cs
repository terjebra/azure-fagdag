using Flight.Api.Domain.Airlines.Queries;

namespace Flight.Api.Controllers.Airlines
{
    public class ApiAirline
    {
        public ApiAirline(QueryAirline airline)
        {
            Code = airline.Code;
            Name = airline.Name;
        }

        public string Code { get; set; }
        public string Name { get; set; }
    }
}