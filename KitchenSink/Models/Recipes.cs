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

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("name")]
        public string IngredientName { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("analyzedInstructions")]
        public Analyzedinstruction[] AnalyzedInstructions { get; set; }
        public MissedIngredients[] missedIngredients { get; set; }
    }

    public class MissedIngredients
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }

    public class Analyzedinstruction
    {
        public string name { get; set; }
        public Step[] steps { get; set; }
    }

    public class Step
    {
        public int number { get; set; }
        public string step { get; set; }
        public Ingredient[] ingredients { get; set; }
        public Equipment[] equipment { get; set; }
        public Length length { get; set; }
    }
    public class Length
    {
        public int number { get; set; }
        public string unit { get; set; }
    }

    public class Ingredient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class Equipment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }



    //public class RecipeArray
    //{
    //    [JsonPropertyName("title")]
    //    public Recipes[] TitleOfRecipe { get; set; }
    //}
}
