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

        //Genre genre = new Genre();
        //List<Genre> genreList = new List<Genre>();
        //private JsonDocument jDoc;
        private IConfiguration _config;

        // 3/8/2020 edits using JsonPropertyName
        GenreArray genres = new GenreArray();

        public MovieController(IConfiguration config)
        {
            _config = config;
        }

        public async Task<GenreArray> GetGenre()
        {
            var SpoonApi = _config["TheMovieDBApiKey"];
            //this using block sets the stage to open the API call
            using (var httpClient = new HttpClient())
            {
                //this using block is the action to get the call.  We have added our key to the request URL per API documentation requirement.
                //this specific url generates the master list of Movie Genres everytime we call it.
                using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/genre/movie/list?api_key=f8a2f6a517044f8633bce74e861f3056&language=en-US"))
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    // 3/8/2020 same as above - deserializing the string response into an array of Drink
                    genres = JsonSerializer.Deserialize<GenreArray>(stringResponse);
                    //jDoc = JsonDocument.Parse(stringResponse);

                    //var genreArrayAsJsonElement = jDoc.RootElement.GetProperty("genres");

                    ////we use the for loop to iterate through the response and set the properties to a Genre Object.  
                    //for (int i = 0; i < genreArrayAsJsonElement.GetArrayLength(); i++)
                    //{
                    //    //We then add that object to a list and return it.
                    //    genreList.Add(new Genre()
                    //    {
                    //        Name = genreArrayAsJsonElement[i].GetProperty("name").ToString(),
                    //        Id = genreArrayAsJsonElement[i].GetProperty("id").ToString(),
                    //    });
                    //}
                }
            }
            return genres;
        }
    }
}