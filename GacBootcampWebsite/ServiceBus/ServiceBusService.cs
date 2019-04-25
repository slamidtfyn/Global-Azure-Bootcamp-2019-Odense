using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace GacBootcampWebsite.ServiceBus
{
    public class ServiceBusService : IServiceBus
    {
        private readonly IQueueClient _queueClient;

        public ServiceBusService(IQueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        public async Task SendMessage(object message)
        {
            var jsonObj = JsonConvert.SerializeObject(message);
            var messageWrapper = new Message(Encoding.UTF8.GetBytes(jsonObj));
            await _queueClient.SendAsync(messageWrapper);
        }
    }
}
