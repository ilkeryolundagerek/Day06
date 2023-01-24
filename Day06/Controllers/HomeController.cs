using Day06.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day06.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Index yapısında çağırdık, etkinleştirilmemişse boş değer gelir.
            ViewBag.ClientID = HttpContext.Session.GetString("client-id");
            return View();
        }

        public IActionResult Privacy()
        {
            CustomUser user = new CustomUser
            {
                Firstname = "ilker",
                Lastname = "turan"
            };
            //Privacy yapısında etkinleştirdik.
            HttpContext.Session.SetString("client-id", user.ToString());

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Scalar action: Tek tip bir veri üzerinden View olmadan işletilir.
        public bool Activate(bool value)
        {
            return !value;
        }

        public ActionResult PartialData()
        {
            return PartialView("_GetData");
        }
    }
}