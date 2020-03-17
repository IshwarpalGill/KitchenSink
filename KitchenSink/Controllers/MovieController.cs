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
        List<Movie> movieList = new List<Movie>();
        Random random = new Random();

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
                }
            }
            return View(genres);
        }

        public async Task<IActionResult> GetRandomMovie(int genre)
        {
            var MovieApiKey = _config["TheMovieDBApiKey"];
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync
                    ($"https://api.themoviedb.org/3/discover/movie?with_genres=18&sort_by=vote_average.desc&vote_count.gte=10&api_key={MovieApiKey}");
                var stringResponse = await response.Content.ReadAsStringAsync();

                JsonDocument jdoc = JsonDocument.Parse(stringResponse);

                var jsonList = jdoc.RootElement.GetProperty("results");

                var list = jsonList.GetArrayLength();

                if (list == 0)
                {
                    return View("GetStarted");
                }
                else
                {

                    foreach (var item in jsonList.EnumerateArray())
                    {
                        var movie = JsonSerializer.Deserialize<Movie>(item.ToString());

                        movieList.Add(movie);
                    }

                    Movie chosenMovie = movieList[random.Next(movieList.Count)];

                    return View(chosenMovie);
                }
            }
        }
    }
}
