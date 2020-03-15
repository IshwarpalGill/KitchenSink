using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KitchenSink.Models;
using Microsoft.Extensions.Configuration;

namespace KitchenSink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _config;
        private DrinkController drinkController = new DrinkController();

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        //TODO: Method that takes in a cuisine from recipe controller and a drink category from drink controller
        //with those 2 parameters, we will call our recommendation API 

        //TODO: How to use foreign keys to call related values (Recommendation.DrinkID 1 = Cocktail)

        //Return all results from recommendation API that match the cuisine and/or drink category
        //Pass those results to respected controllers in order to make API calls 

        public IActionResult Index()
        {
            var SpoonApi = _config["SpoonacularApiKey"];
            var MovieApi = _config["TheMovieDBApiKey"];
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
