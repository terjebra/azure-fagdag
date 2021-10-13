using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Weather.Api.Domain.Yr;

namespace Weather.Api.Domain.Queries
{
    public class GetForecastByCoordinates : IRequest<IList<QueryForecast>>
    {
        public GetForecastByCoordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        
        public double Latitude { get; }
        public double Longitude { get; }

        public class Handler : IRequestHandler<GetForecastByCoordinates, IList<QueryForecast>>
        {
            private readonly IYrApiClient _yrApiClient;

            public Handler(IYrApiClient yrApiClient)
            {
                _yrApiClient = yrApiClient;
            }
            public async Task<IList<QueryForecast>> Handle(GetForecastByCoordinates request, CancellationToken cancellationToken)
            {
                var data = await _yrApiClient.GetForecast(request.Latitude, request.Longitude);
                return data.Properties.TimeSeries.Select(x => new QueryForecast(x)).ToList();
            }
        }
    }
}
