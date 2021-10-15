using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Flight.Api.Domain.FlightSubscriptions.Commands
{
    public class CreateFlightSubscription : IRequest<Unit>
    {
        public CreateFlightSubscription(string userId, string flightId, string airport)
        {
            UserId = userId;
            FlightId = flightId;
            Airport = airport;
        }

        public string UserId { get; }
        public string FlightId { get; }
        public string Airport { get; }

        public class Handler : IRequestHandler<CreateFlightSubscription, Unit>
        {
            private readonly IServiceBus _serviceBus;

            public Handler(IServiceBus serviceBus)
            {
                _serviceBus = serviceBus;
            }

            public async Task<Unit> Handle(CreateFlightSubscription request, CancellationToken cancellationToken)
            {
                await _serviceBus.SendMessage(
                    new FlightNotificationMessage(request.UserId, request.FlightId, request.Airport));
                return Unit.Value;
            }
        }
    }
}
