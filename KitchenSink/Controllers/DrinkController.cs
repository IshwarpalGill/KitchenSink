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
        public async Task<IActionResult> GetDrink(string alcohol)
        {
            List<Drink> drinkList = new List<Drink>();
            int num = random.Next(0, 25);
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
                            Name = jsonList[i].GetProperty("strDrink").GetString()
                            //drinkList[i].GetProperty("stringredient" + (i + 1)).GetString();
                            //drinkList[i].GetProperty("strmeasurement" + (i + 1)).GetString();
                        });
                    }

                }
            }
            return View(drinkList);
        }
    }
}