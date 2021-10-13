using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flight.Api.Domain.Services.Avinor;
using MediatR;

namespace Flight.Api.Domain.Airports.Queries
{
    public class GetAirports : IRequest<IList<QueryAirport>>
    {

        public class Handler : IRequestHandler<GetAirports, IList<QueryAirport>>
        {
            private readonly IAvinorApiClient _avinorApiClient;

            public Handler(IAvinorApiClient avinorApiClient)
            {
                _avinorApiClient = avinorApiClient;
            }
            public async Task<IList<QueryAirport>> Handle(GetAirports request, CancellationToken cancellationToken)
            {
                var airports = await _avinorApiClient.GetAirports();

                return airports.Select(x => new QueryAirport(x.Code, x.Name)).ToList()
;            }
        }
    }
}
