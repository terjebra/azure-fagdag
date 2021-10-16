using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.Services.Avinor;

namespace Flight.Api.Domain.Airlines.Queries
{
    public class GetAirlines : IRequest<IList<QueryAirline>>
    {

        public class Handler : IRequestHandler<GetAirlines, IList<QueryAirline>>
        {
            private readonly IAvinorApiClient _avinorApiClient;

            public Handler(IAvinorApiClient avinorApiClient)
            {
                _avinorApiClient = avinorApiClient;
            }

            public async Task<IList<QueryAirline>> Handle(GetAirlines request, CancellationToken cancellationToken)
            {
                var airlines = await _avinorApiClient.GetAirlines();

                return airlines.Select(x => new QueryAirline(x.Code, x.Name)).ToList()
;            }
        }
    }
}
