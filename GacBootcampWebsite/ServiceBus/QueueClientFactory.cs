using Microsoft.Azure.ServiceBus;

namespace GacBootcampWebsite.ServiceBus
{
    public class QueueClientFactory
    {
        public const string InputQueueName = "email-input";

        public static IQueueClient CreateQueueClient(string connectionString)
        {
            return new QueueClient(connectionString, InputQueueName);
        }
    }
}
