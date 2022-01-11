using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryTemplate;
using UsersTestApi.Entity;

namespace UsersTestApi.Controllers
{
    public partial class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, AppDbContext appContext) // IRepositoryEntity<UserItem> _repository
        {
            _logger = logger;
            currentRepository = GetRepositoryFromContext(appContext);

            PartialOnConstructor();
        }

        private partial void PartialOnConstructor();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return null;//View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
