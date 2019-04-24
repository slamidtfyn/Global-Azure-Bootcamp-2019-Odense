using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GacBootcampWebsite.Controllers
{
    public class KeyVaultController : Controller
    {
        private readonly IConfiguration _configuration;

        public KeyVaultController(IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewData["Secret"] = _configuration["SuperSecret"];
            return View();
        }
    }
}