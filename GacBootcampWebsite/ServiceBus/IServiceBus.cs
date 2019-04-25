using System.Threading.Tasks;

namespace GacBootcampWebsite.ServiceBus
{
    public interface IServiceBus
    {
        Task SendMessage(object message);
    }
}
