using System;
using System.Linq;
using GacBootcampWebsite.Database;
using GacBootcampWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace GacBootcampWebsite.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly SimpleDatabaseContext _dbContext;

        public DatabaseController(SimpleDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            UsersViewModel usersViewModel = null;

            using (_dbContext)
            {
                var users = _dbContext.Users.ToArray();
                usersViewModel = new UsersViewModel(users);
            }

            return View(usersViewModel);
        }
    }
}