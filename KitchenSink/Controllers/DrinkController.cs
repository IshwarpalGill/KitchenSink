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

        Random random = new Random();
        
        DrinkArray drinks = new DrinkArray();

        public async Task<IActionResult> GetDrink()
        {
            int num = random.Next(0, 25);
            char let = (char)('a' + num);

            using (var httpClient = new HttpClient())
            {
                
                using (var response = await httpClient.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?f={let}"))
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    
                    drinks = JsonSerializer.Deserialize<DrinkArray>(stringResponse);
                }
            }
            return View(drinks);
        }
    }
}