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

        List<Recipes> mikeRecipe = new List<Recipes>();
        Random random = new Random();
        KitchenSinkDBContext db = new KitchenSinkDBContext();

        public RecipesController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult GetStarted()
        {
            return View();
        }

        //TODO: When we return the recipe, save the cuisine 

        //TODO: pass this to home controller to eventually make call to DB 


        public async Task<IActionResult> GetRandomRecipe(string protein, string starch, string veggie, string spice, string aromatic)
        {
            var SpoonApiKey = _config["SpoonacularApiKey"];
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync
                    ($"https://api.spoonacular.com/recipes/complexSearch?includeIngredients={protein},+{starch},+{veggie},+{spice},+{aromatic}&instructionsRequired=true&addRecipeInformation=true&apiKey={SpoonApiKey}");
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

                    var chosenId = chosenRecipe.Id;

                    using var response2 = await httpClient.GetAsync
                    ($"https://api.spoonacular.com/recipes/{chosenId}/information?includeNutrition=false&apiKey={SpoonApiKey}");

                    var stringResponse2 = await response2.Content.ReadAsStringAsync();

                    var recipes2 = JsonSerializer.Deserialize<Recipes>(stringResponse2.ToString());


                    //-----This will allow us to pass the matching cuisine from the Recipe Object anywhere we need

                    //foreach (Cuisine cus in db.Cuisine)
                    //{
                    //    if (recipes2.cuisines.Contains(cus.Cuisine1))
                    //    {

                    //    }
                    //    else
                    //    {

                    //    }
                    //}

                    //-----
                    
                    
                    return View(recipes2);
                }
            }
        }
        public IActionResult TestRandomRecipe()
        {
            return View();
        }
    }
}
https://scontent-iad3-1.cdninstagram.com/v/t51.2885-15/e35/89933484_809956926153730_7599352728966565164_n.jpg?_nc_ht=scontent-iad3-1.cdninstagram.com&_nc_cat=1&_nc_ohc=aTc5bO4JmBkAX-RzIKl&oh=0606143c88e455adaad33604637e3fb0&oe=5E75137D