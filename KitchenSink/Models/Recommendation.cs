using System;
using System.Collections.Generic;

namespace KitchenSink.Models
{
    public partial class Recommendation
    {
        public int Id { get; set; }
        public int DrinkId { get; set; }
        public int RecipeId { get; set; }
        public int GenreId { get; set; }

        public virtual Drinks Drink { get; set; }
        public virtual Genres Genre { get; set; }
        public virtual Cuisine Recipe { get; set; }
    }
}
