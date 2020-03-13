using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KitchenSink.Models
{
    public class Recipes
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("image")]
        public string Image { get; set; }
        
        [JsonPropertyName("usedIngredients")]
        public Array[] UsedIngredients { get; set; }

        [JsonPropertyName("missedIngredients")]
        public string MissedIngredients { get; set; }
    }

    public class RecipeArray
    {
        [JsonPropertyName("")]
        public Recipes[] TitleOfRecipe { get; set; }
    }
}
