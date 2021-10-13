namespace Flight.Api.Domain.Airlines.Queries
{
    public class QueryAirline
    {
        public QueryAirline(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Name { get; set; }
        public string Code { get; set; }
    }
}