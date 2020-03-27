using System;
using System.Collections.Generic;

namespace KitchenSink.Models
{
    public partial class UserItems
    {
        public int UserItems1 { get; set; }
        public string UserId { get; set; }
        public string RecipeId { get; set; }
        public string DrinkId { get; set; }
        public string MovieId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
