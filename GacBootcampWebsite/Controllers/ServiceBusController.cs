using GacBootcampWebsite.Models;
using GacBootcampWebsite.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using ServiceBus.Messages;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GacBootcampWebsite.Controllers
{
    public class ServiceBusController : Controller
    {
        const int InternalServerErrorHttpStatusCode = 500;
        private readonly IServiceBus _serviceBus;

        public ServiceBusController(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendEmail(SendEmailRequest sendEmailRequest)
        {
            var msg = new SendEmailCommand()
            {
                Email = sendEmailRequest.Email,
                Message = sendEmailRequest.Message,
                Subject = sendEmailRequest.Subject
            };

            await _serviceBus.SendMessage(msg);

            return RedirectToAction(nameof(Index));
        }
    }
}