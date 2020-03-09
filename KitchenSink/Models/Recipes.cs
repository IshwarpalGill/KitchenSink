using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KitchenSink.Models
{
    //We created this Model based on the expected results of the Spoontacular API.  
    //Reading documentation and breaking out the Json element, I pulled out some basic properties to help display in the view
    public class Recipes
    {
        //public Recipes() { }

        //public Recipes(string title, string id)
        //{
        //    Id = id;
        //    Title = title;
        //}
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("aisle")]
        public string FoodCategory { get; set; }
        [JsonPropertyName("name")]
        public string IngredientName { get; set; }
    }

    public class RecipeArray
    {
        [JsonPropertyName("recipes")]
        public Recipes[] TitleOfRecipe { get; set; }
    }
}
