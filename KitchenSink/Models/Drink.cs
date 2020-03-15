using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KitchenSink.Models
{
    public class Drink
    {
        public Drink() { }
        public Drink(string idDrink, string strDrink, string strCategory)
        {
            Id = idDrink;
            Name = strDrink;
            Category = strCategory;

        }
        [JsonPropertyName("idDrink")]
        public string Id { get; set; }
        [JsonPropertyName("strDrink")]
        public string Name { get; set; }
        [JsonPropertyName("strDrinkThumb")]
        public string Image { get; set; }
        [JsonPropertyName("strCategory")]
        public string Category { get; set; }
        [JsonPropertyName("strInstructions")]
        public string Instructions { get; set; }
        [JsonPropertyName("strAlcoholic")]
        public string Alcoholic { get; set; }
        //ingredients
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public object strIngredient5 { get; set; }
        public object strIngredient6 { get; set; }
        public object strIngredient7 { get; set; }
        public object strIngredient8 { get; set; }
        public object strIngredient9 { get; set; }
        public object strIngredient10 { get; set; }
        public object strIngredient11 { get; set; }
        public object strIngredient12 { get; set; }
        public object strIngredient13 { get; set; }
        public object strIngredient14 { get; set; }
        public object strIngredient15 { get; set; }
        //measures
        public string strMeasure1 { get; set; }
        public string strMeasure2 { get; set; }
        public string strMeasure3 { get; set; }
        public string strMeasure4 { get; set; }
        public object strMeasure5 { get; set; }
        public object strMeasure6 { get; set; }
        public object strMeasure7 { get; set; }
        public object strMeasure8 { get; set; }
        public object strMeasure9 { get; set; }
        public object strMeasure10 { get; set; }
        public object strMeasure11 { get; set; }
        public object strMeasure12 { get; set; }
        public object strMeasure13 { get; set; }
        public object strMeasure14 { get; set; }
        public object strMeasure15 { get; set; }
    }

    public class DrinkArray
    {
        [JsonPropertyName("drinks")]
        public Drink[] Drinks { get; set; }
    }


    public class Rootobject
    {
        public Drink[] drinks { get; set; }
    }

}
