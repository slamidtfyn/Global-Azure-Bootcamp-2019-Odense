using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GacBootcampWebsite.Models;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System;

namespace GacBootcampWebsite.Controllers
{
    public class ApplicationInsightsController : Controller
    {
        public async Task<IActionResult> Index(bool success, string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.Response = DefaultFormResponse.Create(success, message);

            var model = new LogViewModel();
            model.Entries = await GetLogEntries();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToLog(string logEntry)
        {      
            if (string.IsNullOrEmpty(logEntry))
                return RedirectToAction("Index", new { success = false, message = "Can not add empty input to log" });

            await WriteToLog(logEntry);
            return RedirectToAction("Index", new { success = true, message = $"{logEntry} added to log" });
        }

        private async Task WriteToLog(string entry)
        {
            if (string.IsNullOrEmpty(entry))
                throw new ArgumentNullException("No input given");

            var pathToLog = GetLogFilePath();
            await WriteToLog(pathToLog, entry);
        }

        private async Task WriteToLog(string pathToLog, string entry)
        {
            if (!System.IO.File.Exists(pathToLog))
                throw new FileNotFoundException($"Can not find the file on path {pathToLog}");

            await System.IO.File.AppendAllTextAsync(pathToLog, entry);
        }

        private async Task<List<string>> GetLogEntries()
        {
            var pathToLog = GetLogFilePath();
            var logEntries = await GetLogEntries(pathToLog);

            return logEntries.ToList();
        }

        private async Task<string[]> GetLogEntries(string pathToLog)
        {
            if (!System.IO.File.Exists(pathToLog))
                throw new FileNotFoundException($"Can not find the file on path {pathToLog}");

            var content = await System.IO.File.ReadAllLinesAsync(pathToLog);
            return content;
        }

        private string GetLogFilePath()
        {
            string parent = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return Path.Combine(parent, "Logs", "log.txt");
        }
    }
}
