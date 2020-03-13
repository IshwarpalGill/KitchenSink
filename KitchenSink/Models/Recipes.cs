using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KitchenSink.Models
{
    public class Recipes
    {
        public Recipes() { }

        public Recipes(string title, int id)
        {
            Id = id;
            Title = title;
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("aisle")]
        public string FoodCategory { get; set; }
        [JsonPropertyName("name")]
        public string IngredientName { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }

        public MissedIngredients[] missedIngredients { get; set; }
    }

    public class MissedIngredients
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }



    public class RecipeArray
    {
        [JsonPropertyName("title")]
        public Recipes[] TitleOfRecipe { get; set; }
    }
}
