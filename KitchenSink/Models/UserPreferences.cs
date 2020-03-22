using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitchenSink.Models
{
    public partial class UserPreferences
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CustomerId { get; set; }
        public int? SavedRecommendation { get; set; }
        public string ExcludedGenre { get; set; }
        public string ExcludedCuisine { get; set; }
        public string ExcludedDrink { get; set; }
        public string SavedMovie { get; set; }
        public string SavedRecipe { get; set; }
        public string SavedDrink { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
