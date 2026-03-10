using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriGoals
{
    public class ModelsOFF
    {
    }

    // Models.cs
    public class Nutriments
    {
        public float energy_100g { get; set; }
        public float carbohydrates_100g { get; set; }
        public float proteins_100g { get; set; }
        public float fat_100g { get; set; }
    }

    public class Product
    {
        public string product_name { get; set; }
        public string brands { get; set; }
        public string ingredients_text { get; set; }
        public Nutriments nutriments { get; set; }
    }

    public class ProductoOFF
    {
        public Product product { get; set; }
        public int status { get; set; }
    }

}
