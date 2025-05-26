using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCSiteTemplate.Models;

namespace MVCSiteTemplate.Controllers
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
            return View();
        }

        [HttpGet]
        public IActionResult App()
        {
            FizzBuzz model = new()
            {
                FizzValue = 3,
                BuzzValue = 5
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult App(FizzBuzz model)
        {
            List<string> fbItems = [];
            bool isFizz;
            bool isBuzz;

            for (int i = 1; i <= 100; i++)
            {
                isFizz = (i % model.FizzValue == 0);
                isBuzz = (i % model.BuzzValue == 0);

                if (isFizz && isBuzz)
                {
                    fbItems.Add("FizzBuzz");
                }
                else if (isFizz)
                {
                    fbItems.Add("Fizz");
                }
                else if (isBuzz)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }
            }

            model.Result = fbItems;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
