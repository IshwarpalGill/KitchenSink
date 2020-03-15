using System;
using System.Collections.Generic;

namespace KitchenSink.Models
{
    public partial class Drinks
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public bool? NonAlcoholic { get; set; }
    }
}
