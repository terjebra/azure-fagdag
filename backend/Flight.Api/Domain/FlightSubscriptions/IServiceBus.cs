using System.Threading.Tasks;

namespace Flight.Api.Domain.FlightSubscriptions
{
    public interface IServiceBus
    {
        Task SendMessage<T>(T message);
    }
}