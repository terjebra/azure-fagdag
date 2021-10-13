using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flight.Api.Domain.Services.Avinor;
using MediatR;

namespace Flight.Api.Domain.FlightStatuses.Queries
{
    public class GetFlightStatuses : IRequest<IList<QueryFlightStatus>>
    {
        public class Handler : IRequestHandler<GetFlightStatuses, IList<QueryFlightStatus>>
        {
            private readonly IAvinorApiClient _avinorApiClient;

            public Handler(IAvinorApiClient avinorApiClient)
            {
                _avinorApiClient = avinorApiClient;
            }
            public async Task<IList<QueryFlightStatus>> Handle(GetFlightStatuses request, CancellationToken cancellationToken)
            {
                var statuses = await _avinorApiClient.GetFlightStatuses();

                return statuses.Select(x => new QueryFlightStatus(x.Code, x.TextEnglish)).ToList();
            }
        }
    }
}
