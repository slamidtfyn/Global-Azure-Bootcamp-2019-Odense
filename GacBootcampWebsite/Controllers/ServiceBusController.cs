using GacBootcampWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GacBootcampWebsite.Controllers
{
    public class ServiceBusController : Controller
    {
        const int InternalServerErrorHttpStatusCode = 500;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendEmail([FromServices]IOptions<ServiceBusOptions> options, SendEmailRequest sendEmailRequest)
        {
            var email = Newtonsoft.Json.JsonConvert.SerializeObject(sendEmailRequest);
            var messagecontent = System.Text.Encoding.UTF8.GetBytes(email);
            var qc = new Microsoft.Azure.ServiceBus.QueueClient(options.Value.ConnectionString, "email-input");
            await qc.SendAsync(new Microsoft.Azure.ServiceBus.Message(messagecontent));
            // var random = new Random();
            // Thread.Sleep(random.Next(3000, 8000));

            // if(random.Next(0, 1) > 0)
            //     return StatusCode(InternalServerErrorHttpStatusCode);

            return RedirectToAction(nameof(Index));
        }
    }
}