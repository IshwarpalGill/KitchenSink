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

        GenreArray genres = new GenreArray();

        public MovieController(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IActionResult> GetGenre()
        {
            var key = _config["TheMovieDBApiKey"];
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://api.themoviedb.org/3/genre/movie/list?api_key={key}&language=en-US"))
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    genres = JsonSerializer.Deserialize<GenreArray>(stringResponse);
                }
            }
            return View(genres);
        }
    }
}