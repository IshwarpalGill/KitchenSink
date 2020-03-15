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
        private JsonDocument jDoc;
        Random random = new Random();
        
        DrinkArray drinks = new DrinkArray();
        
        public IActionResult Drink()
        {
            return View();
        }


        //TODO: Change GetDrink to be dynamic using ingredients returned from user input (similar to recipe)

        //TODO: When we return the drink, save the category 

        //TODO: pass this to home controller to eventually make call to DB 

        public async Task<List<Drink>> GetDrink(string alcohol)
        {
            List<Drink> drinkList = new List<Drink>();
            //int num = random.Next(0, 25);
            //char let = (char)('a' + num);

            using (var httpClient = new HttpClient())
            {

                //using (var response = await httpClient.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?f={let}"))
                using (var response = await httpClient.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?i={alcohol}"))
                //using (var response = await httpClient.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=11007"))
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();

                    //drinks = JsonSerializer.Deserialize<DrinkArray>(stringResponse);
                    jDoc = JsonDocument.Parse(stringResponse);
                    var jsonList = jDoc.RootElement.GetProperty("drinks");
                    for (int i = 0; i < jsonList.GetArrayLength(); i++)
                    {
                        drinkList.Add(new Drink()
                        {
                            Id = jsonList[i].GetProperty("idDrink").GetString(),
                            Name = jsonList[i].GetProperty("strDrink").GetString(),
                            Image = jsonList[i].GetProperty("strDrinkThumb").GetString()
                        });

                    }

                }

                //chosenDrink = drinkList[random.Next(0, drinkList.Count)];
                //string drinkID = chosenDrink.Id;
                //var drinkRecieved = RndDrink(drinkList);
            }
            return drinkList;
        }
        public IActionResult RndDrink(List<Drink> drinkList)
        {
            var chosenDrink = drinkList[random.Next(0, drinkList.Count)];
            string drinkID = chosenDrink.Id;
            var DrinkRecieved = GetDrinkInfo(drinkID);
            return View(DrinkRecieved);
        }

        public async Task<IActionResult> GetDrinkInfo(string drinkID)
        {
            Drink drink = new Drink();
            //var chosenDrink = drinkList[random.Next(0, drinkList.Count)];
            //string drinkID = chosenDrink.Id;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={drinkID}"))
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    drink = JsonSerializer.Deserialize<Drink>(stringResponse);
                }
            }
            return View(drink);
        }
    }
}