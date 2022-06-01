using Microsoft.AspNetCore.Mvc;
using NegotiationTask.Models;
using System.Diagnostics;

namespace NegotiationTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Students> _student;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _student = new List<Students>
            {
                new Students{ Id = 1,Name = "Mark", Class="8th" },
                new Students{ Id = 2,Name = "Abaseen", Class="9th" },
                new Students{ Id = 2,Name = "Khan", Class="9th" }

            };
        }

        public IActionResult Index()
        {
            return View();
        }

      

        public IActionResult CheckingForAjax()
        {
            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_GetData.cshtml", _student);
            }
            else
            {
                return View("Privacy");
            }
        }

        public IActionResult FormateChecking()
        {
            if (HttpContext.Request.Headers["Accept"].ToString().Contains("application/json"))
            {
                return Ok(_student);
            }


            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}