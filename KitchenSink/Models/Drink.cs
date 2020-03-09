using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KitchenSink.Models
{
    //We created this Model based on the expected results of the Cocktail DB.  
    //Reading documentation and breaking out the Json element, we pulled out some basic properties to help display in the view
    public class Drink
    {
        //public Drink() { }
        //public Drink(string idDrink, string strDrink, string strCategory)
        //{
        //    Id = idDrink;
        //    Name = strDrink;
        //    Category = strCategory;

        //}
        [JsonPropertyName("idDrink")]
        public string Id { get; set; }
        [JsonPropertyName("strDrink")]
        public string Name { get; set; }
        [JsonPropertyName("strCategory")]
        public string Category { get; set; }
    }

    public class DrinkArray
    {
        [JsonPropertyName("drinks")]
        public Drink[] Drinks { get; set; }
    }
}
