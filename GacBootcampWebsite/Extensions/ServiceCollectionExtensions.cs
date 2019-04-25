using GacBootcampWebsite.ServiceBus;
using Microsoft.Extensions.DependencyInjection;

namespace GacBootcampWebsite.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceBus(this IServiceCollection self, string connectionString)
        {
            self.AddSingleton(QueueClientFactory.CreateQueueClient(connectionString));
            self.AddTransient<IServiceBus, ServiceBusService>();
        }
    }
}
