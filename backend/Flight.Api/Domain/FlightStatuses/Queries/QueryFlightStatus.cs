namespace Flight.Api.Domain.FlightStatuses.Queries
{
    public class QueryFlightStatus
    {
        public QueryFlightStatus(string code, string text)
        {
            Code = code;
            Text = text;
        }

        public string Text { get; set; }
        public string Code { get; set; }
    }
}