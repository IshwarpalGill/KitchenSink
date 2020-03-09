using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using KitchenSink.Models;
using Microsoft.AspNetCore.Mvc;

namespace KitchenSink.Controllers
{
    public class DrinkController : Controller
    {
        //Drink drink = new Drink();
        //List<Drink> drinkList = new List<Drink>();
        //private JsonDocument jDoc;
        Random random = new Random();
        
        // 3/8/2020 edits using JsonPropertyName
        DrinkArray drinks = new DrinkArray();

        public async Task<DrinkArray> GetDrink()
        {
            int num = random.Next(0, 25);
            char let = (char)('a' + num);

            //this using block sets the stage to open the API call
            using (var httpClient = new HttpClient())
            {
                //this using block is the action to get the call.  We do not need a key to make request calls to this API.
                //this specific url generates a random list of Drinks based on the first letter of the drink name everytime we call it.
                //I used a random letter generator to produce a new letter in the request URL every call just for testing
                using (var response = await httpClient.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?f={let}"))
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    // 3/8/2020 same as above - deserializing the string response into an array of Drink
                    drinks = JsonSerializer.Deserialize<DrinkArray>(stringResponse);
                    //jDoc = JsonDocument.Parse(stringResponse);

                    //var drinkArrayAsJsonElement = jDoc.RootElement.GetProperty("drinks");

                    //we use the for loop to iterate through the response and set the properties to a Drink Object. 
                    //for (int i = 0; i < drinkArrayAsJsonElement.GetArrayLength(); i++)
                    //{
                    //    //We then add that object to a list and return it.
                    //    drinkList.Add(new Drink()
                    //    {
                    //        Name = drinkArrayAsJsonElement[i].GetProperty("strDrink").ToString(),
                    //        Id = drinkArrayAsJsonElement[i].GetProperty("idDrink").ToString(),
                    //        Category = drinkArrayAsJsonElement[i].GetProperty("strCategory").ToString()
                    //    }); 
                    //}
                }
            }
            return drinks;
        }
    }
}