using Flight.Api.Domain.FlightStatuses.Queries;

namespace Flight.Api.Controllers.FlightStatus
{
    public class ApiFlightStatus
    {
        public ApiFlightStatus(QueryFlightStatus status)
        {
            Code = status.Code;
            Text = status.Text;
        }

        public string Code { get; set; }
        public string Text { get; set; }
    }
}