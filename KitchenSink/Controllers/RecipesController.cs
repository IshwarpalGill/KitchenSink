using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using KitchenSink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KitchenSink.Controllers
{
    public class RecipesController : Controller
    {
        private IConfiguration _config;

        RecipeArray recipe = new RecipeArray();

        public RecipesController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult GetStarted()
        {
            return View("GetRandomRecipe");
        }

        public async Task<IActionResult> GetRandomRecipe()
        {
            var key = _config["SpoonacularApiKey"];
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://api.spoonacular.com/recipes/random?number=1&tags=vegetarian,dessert&apiKey={key}"))
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    recipe = JsonSerializer.Deserialize<RecipeArray>(stringResponse);
                }
            }
            return View(recipe);
        }
    }
}