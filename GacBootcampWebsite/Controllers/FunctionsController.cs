using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GacBootcampWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace GacBootcampWebsite.Controllers
{
    public class FunctionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendEmail(SendEmailRequest sendEmailRequest)
        {
            var functionUrl = "https://globalazurebootcampodense.azurewebsites.net/api/HttpTrigger1?code=gVBiAVaXsCnhHqXR7I19jga679nVGoLke266nDvWdVV6OdfLuME4TA==";
            using (var client = new HttpClient())
            {
                // OFFload to Azure Functions
                var result = await client.PostAsJsonAsync<SendEmailRequest>(functionUrl, sendEmailRequest);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Success");
                }
            }
            // At this point it fialed to send to the endpoint, we shuold handle it
            return RedirectToAction("Fail");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Fail()
        {
            return View();
        }
    }
}