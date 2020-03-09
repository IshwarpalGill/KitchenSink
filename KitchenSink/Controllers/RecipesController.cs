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
        public async Task<RecipeArray> GetRandomRecipe()
        {
            var SpoonApi = _config["SpoonacularApiKey"];
            //this using block sets the stage to open the API call
            using (var httpClient = new HttpClient())
            {
                //this using block is the action to get the call.  We have added our key to the end of the request URL per API documentation requirement.
                //this specific url generates 1 random recipe everytime we call it.
                using (var response = await httpClient.GetAsync($"https://api.spoonacular.com/recipes/random?number=1&tags=vegetarian,dessert&apiKey={SpoonApi}"))
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    // 3/8/2020 edits using JsonPropertyName
                    recipe = JsonSerializer.Deserialize<RecipeArray>(stringResponse);
                    //jDoc = JsonDocument.Parse(stringResponse);

                    //var arrayAsJsonElement = jDoc.RootElement.GetProperty("recipes");

                    ////the use of a for loop is not really necessary since the API call is only returning 1 recipe.  However, we use it to stay consistent with other calls.
                    //for (int i = 0; i < arrayAsJsonElement.GetArrayLength(); i++)
                    //{
                    //    //we use the for loop to add the Recipe Object to a list and then return it.
                    //    recipeList.Add(new Recipes()
                    //    {
                    //        Title = arrayAsJsonElement[i].GetProperty("title").ToString(),
                    //        Id = arrayAsJsonElement[i].GetProperty("id").ToString(),
                    //    }); ;
                    //}
                }
            }
            return recipe;
        }
    }
}