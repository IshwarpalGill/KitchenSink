using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KitchenSink.Models
{
    //We created this Model based on the expected results of the The Movie DB.  
    //Reading documentation and breaking out the Json element, I pulled out some basic properties to help display in the view
    public class Genre
    {
        //public Genre() { }
        //public Genre(string id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class GenreArray
    {
        [JsonPropertyName("genres")]
        public Genre[] Genres { get; set; }
    }
}
