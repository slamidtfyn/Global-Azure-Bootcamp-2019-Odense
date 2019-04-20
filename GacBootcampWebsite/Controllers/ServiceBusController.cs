using GacBootcampWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace GacBootcampWebsite.Controllers
{
    public class ServiceBusController : Controller
    {
        const int InternalServerErrorHttpStatusCode = 500;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendEmail(SendEmailRequest sendEmailRequest)
        {
            var random = new Random();
            Thread.Sleep(random.Next(3000, 8000));

            if(random.Next(0, 1) > 0)
                return StatusCode(InternalServerErrorHttpStatusCode);

            return RedirectToAction(nameof(Index));
        }
    }
}