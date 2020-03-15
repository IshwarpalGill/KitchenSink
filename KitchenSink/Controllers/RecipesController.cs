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
        List<Recipes> mikeRecipe = new List<Recipes>();
        Random random = new Random();

        public RecipesController(IConfiguration config)
        {
            _config = config;
        }
        //public async Task<IActionResult> GetRandomRecipe(string protein, string starch, string veggie, string spice, string aromatic)
        public IActionResult GetStarted()
        {
            return View();
        }

        //TODO: When we return the recipe, save the cuisine 

        //TODO: pass this to home controller to eventually make call to DB 


        public async Task<IActionResult> GetRandomRecipe(string protein, string starch, string veggie, string spice, string aromatic)
        {
            var SpoonApiKey = _config["SpoonacularApiKey"];
            //this using block sets the stage to open the API call
            using (var httpClient = new HttpClient())
            {
                //this using block is the action to get the call.  We have added our key to the end of the request URL per API documentation requirement.
                //this specific url generates 1 random recipe everytime we call it.
                using var response = await httpClient.GetAsync
                    ($"https://api.spoonacular.com/recipes/complexSearch?includeIngredients={protein},{starch},{veggie},{spice},{aromatic}&instructionsRequired=true&addRecipeInformation=true&apiKey={SpoonApiKey}");
                var stringResponse = await response.Content.ReadAsStringAsync();

                JsonDocument jdoc = JsonDocument.Parse(stringResponse);

                var jsonList = jdoc.RootElement.GetProperty("results");

                var list = jsonList.GetArrayLength();

                if (list == 0)
                {
                    return View("GetStarted");
                }
                else
                {

                    foreach (var item in jsonList.EnumerateArray())
                    {
                        var recipes = JsonSerializer.Deserialize<Recipes>(item.ToString());

                        mikeRecipe.Add(recipes);
                    }

                    Recipes chosenRecipe = mikeRecipe[random.Next(mikeRecipe.Count)];

                    return View(chosenRecipe);
                }
            }
        }
        public IActionResult TestRandomRecipe()
        {
            return View();
        }
    }
}