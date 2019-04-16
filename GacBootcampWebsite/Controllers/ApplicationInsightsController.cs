using GacBootcampWebsite.Models;
using GacBootcampWebsite.Models.ApplicationInsights;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GacBootcampWebsite.Controllers
{
    public class ApplicationInsightsController : Controller
    {
        private readonly TelemetryClient _telemetryClient;

        public ApplicationInsightsController()
        {
            _telemetryClient = new TelemetryClient();      
        }

        public async Task<IActionResult> Index(bool success, string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.Response = DefaultFormResponse.Create(success, message);

            var model = new ApplicationInsightsViewModel();
            model.Table = await GetAiTable();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToLog(string logEntry)
        {      
            if (string.IsNullOrEmpty(logEntry))
                return RedirectToAction("Index", new { success = false, message = "Can not add empty input to log" });

            WriteToLog(logEntry);
            return RedirectToAction("Index", new { success = true, message = $"{logEntry} added to log" });
        }

        private void WriteToLog(string entry)
        {
            if (string.IsNullOrEmpty(entry))
                throw new ArgumentNullException("No input given");

            _telemetryClient.TrackEvent(entry);
            _telemetryClient.Flush();
        }

        private async Task<ApplicationInsightsTable> GetAiTable()
        {
            var apiKey = "ds4jpb87wqr3wva8i6ubooszg2cj3rmx8ghrlnqm";
            var query = string.Format("customEvents | project name, timestamp | order by timestamp ");

            var url = string.Format($"https://api.applicationinsights.io/v1/apps/1c6fa4ce-4e67-470c-95ca-1d845ff6f62c/query?query={query}");
            Console.WriteLine(url);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            HttpResponseMessage response = await client.GetAsync(url);

            var table = GetFirstTableOfResponse(response);
 
            return table;
        }

        public ApplicationInsightsTable GetFirstTableOfResponse(HttpResponseMessage response)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            ApplicationInsightsResult aiResult = JsonConvert.DeserializeObject<ApplicationInsightsResult>(result);

            return aiResult.GetFirstTable();
        }
    }
}
