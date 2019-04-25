using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceBus.Messages;
using System.Text;

namespace ServiceBusFunctions
{
    public static class SendEmailFunction
    {
        [FunctionName("SendEmailFunction")]
        public static void Run([ServiceBusTrigger("email-input", Connection = "ServiceBusConnectionString")]Message message, ILogger log)
        {
            if(TryExtractCommand(message, out var command) == false)
            {
                log.LogError("Could not extract command");
            }

            log.LogInformation($"Ready to send Email {command.Email} - {command.Subject}!!");

            // Write  your favorite email implementation here!
        }

        private static bool TryExtractCommand(Message message, out SendEmailCommand command)
        {
            var body = Encoding.UTF8.GetString(message.Body);
            command = JsonConvert.DeserializeObject<SendEmailCommand>(body);

            return command != null;
        }
    }
}
