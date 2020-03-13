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
        //Recipes recipes = new Recipes();
        //List<Recipes> recipeList = new List<Recipes>();
        //private JsonDocument jDoc;
        private IConfiguration _config;

        // 3/8/2020 edits using JsonPropertyName
        RecipeArray recipe = new RecipeArray();

        public RecipesController(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IActionResult> GetRandomRecipe(string protein, string starch, string veggie, string spice, string aromatic)
        {
            var SpoonApiKey = _config["SpoonacularApiKey"];
            //this using block sets the stage to open the API call
            using (var httpClient = new HttpClient())
            {
                //this using block is the action to get the call.  We have added our key to the end of the request URL per API documentation requirement.
                //this specific url generates 1 random recipe everytime we call it.
                using var response = await httpClient.GetAsync($"https://api.spoonacular.com/recipes/findByIngredients?ingredients={protein},+{starch},+{veggie},+{spice},+{aromatic}&number=1&apiKey=[SpoonApiKey]");
                var stringResponse = await response.Content.ReadAsStringAsync();

                //cookbook = new Recipes

                //Parses the text representing a single JSON value into an
                //an instance of the type specified by a generic type parameter

                //cookbook = parsed string response
                //return as Recipes object
                //which consists of strings and ints

                recipe = JsonSerializer.Deserialize<RecipeArray>(stringResponse);
            }
            return View(recipe);
        }
    }
}