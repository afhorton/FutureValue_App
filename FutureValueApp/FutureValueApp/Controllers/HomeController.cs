using FutureValueApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FutureValueApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        public IActionResult Index()
        {
            ViewBag.FV = 0;
            return View();
        }

        [HttpPost]
        // do calculation using data collected on the form
        public IActionResult Index(FVModel dataModel)
        {
            if(ModelState.IsValid)
            {
                ViewBag.FV = dataModel.CalculateFutureValue();
            } else
            {
                ViewBag.FV = 0;
            }
            return View(dataModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}