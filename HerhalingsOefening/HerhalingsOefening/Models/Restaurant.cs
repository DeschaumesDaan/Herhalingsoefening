using System;
using System.Collections.Generic;
using System.Text;

namespace HerhalingsOefening.Models
{
    public class Restaurant
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cuisines { get; set; }
        public int PriceRange { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }

        public class Location
        {
            public string Address { get; set; }
            public string City { get; set; }
            public string Locality { get; set; }
        }
    }
}
