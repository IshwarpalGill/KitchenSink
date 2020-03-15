using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using KitchenSink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KitchenSink.Controllers
{
    public class MovieController : Controller
    {
        private IConfiguration _config;
        private JsonDocument jDoc;

        GenreArray genres = new GenreArray();

        public MovieController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult GetStarted()
        {
            return View();
        }

        //TODO: Create method that takes in genreID returned from DB & calls API to return movie 
        // 1) Call DB 
        // 2) Return MovieDBId genre from DB 
        // 3) Use this ID to make call to Movie DB, return movie 
        // 4) Pass that to model to the view 


        //TODO: Create method to return a random movie
        public async Task<IActionResult> GetGenre()
        {
            List<Genre> genreList = new List<Genre>();
            var key = _config["TheMovieDBApiKey"];
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://api.themoviedb.org/3/genre/movie/list?api_key={key}&language=en-US"))
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    genres = JsonSerializer.Deserialize<GenreArray>(stringResponse);
                    //jDoc = JsonDocument.Parse(stringResponse);
                    //var jsonList = jDoc.RootElement.GetProperty("genres");
                    //for (int i = 0; i < jsonList.GetArrayLength(); i++)
                    //{
                    //    genreList.Add(new Genre()
                    //    {
                    //        Id = jsonList[i].GetProperty("id").GetInt32(),
                    //        Name = jsonList[i].GetProperty("name").GetString()
                    //    });
                    //}
                }
            }
            return View(genres);
        }
    }
}