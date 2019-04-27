using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.SendGrid;
using SendGrid.Helpers.Mail;
using Newtonsoft.Json;
using Models;
using System.Text;

namespace ServiceBusFunctions
{
    public static class EmailInput
    {
        [FunctionName("EmailInput")]
        public static void Run([ServiceBusTrigger("email-input",
         Connection = "ServiceBusConnectionString")]string myQueueItem,
         [SendGrid(ApiKey = "SendGridApikey")] out SendGridMessage message,
         ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var email= JsonConvert.DeserializeObject<SendEmailRequest>(myQueueItem);
            message = new SendGridMessage();
            message.AddTo(email.Email);
            message.AddContent("text/html", email.Message);
            message.SetFrom(new EmailAddress("slamidtfyn@gmail.com"));
            message.SetSubject(email.Subject);

        }
    }
}
