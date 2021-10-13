namespace Flight.Api.Domain.Airports.Queries
{
    public class QueryAirport
    {
        public QueryAirport(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Name { get; set; }
        public string Code { get; set; }
    }
}
