using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GacBootcampWebsite.Controllers
{
    [Authorize]
    public class ADController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}