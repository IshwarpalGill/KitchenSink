using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KitchenSink.Models
{
    public class Test
    {

        public class Rootobject
        {
            public Result[] results { get; set; }
            public int offset { get; set; }
            public int number { get; set; }
            public int totalResults { get; set; }
        }

        public class Result
        {
            public bool vegetarian { get; set; }
            public bool vegan { get; set; }
            public bool glutenFree { get; set; }
            public bool dairyFree { get; set; }
            public bool veryHealthy { get; set; }
            public bool cheap { get; set; }
            public bool veryPopular { get; set; }
            public bool sustainable { get; set; }
            public int weightWatcherSmartPoints { get; set; }
            public string gaps { get; set; }
            public bool lowFodmap { get; set; }
            public int preparationMinutes { get; set; }
            public int cookingMinutes { get; set; }
            public string sourceUrl { get; set; }
            public string spoonacularSourceUrl { get; set; }
            public int aggregateLikes { get; set; }
            public float spoonacularScore { get; set; }
            public float healthScore { get; set; }
            public string creditsText { get; set; }
            public string sourceName { get; set; }
            public float pricePerServing { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public int readyInMinutes { get; set; }
            public int servings { get; set; }
            public string image { get; set; }
            public string imageType { get; set; }
            public string summary { get; set; }
            public string[] cuisines { get; set; }
            public string[] dishTypes { get; set; }
            public string[] diets { get; set; }
            public string[] occasions { get; set; }
            public Winepairing winePairing { get; set; }
            public Analyzedinstruction[] analyzedInstructions { get; set; }
            public object originalId { get; set; }
            public int usedIngredientCount { get; set; }
            public int missedIngredientCount { get; set; }
            public int likes { get; set; }
        }

        public class Winepairing
        {
            public string[] pairedWines { get; set; }
            public string pairingText { get; set; }
            public Productmatch[] productMatches { get; set; }
        }

        public class Productmatch
        {
            public int id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string price { get; set; }
            public string imageUrl { get; set; }
            public float averageRating { get; set; }
            public float ratingCount { get; set; }
            public float score { get; set; }
            public string link { get; set; }
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

    }
}