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
        private JsonDocument jdoc;
        Recipes eat = new Recipes();
        public RecipesController(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IActionResult> GetRandomRecipe()
        {
            var key = _config["SpoonacularApiKey"];
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://api.spoonacular.com/recipes/716429/analyzedInstructions&apiKey={key}"))
                {

                    var stringResponse = await response.Content.ReadAsStringAsync();

                    jdoc = JsonDocument.Parse(stringResponse);

                    foreach (var item in jdoc.RootElement.EnumerateArray())
                    {
                        var recipe = JsonSerializer.Deserialize<Recipes>(item.ToString());
                    }
                }
                return View(eat);
            }
        }
    }
}