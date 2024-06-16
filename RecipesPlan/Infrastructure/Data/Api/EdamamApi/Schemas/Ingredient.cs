using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesPlan.Infrastructure.Data.Api.EdamamApi.Schemas
{
    public class Ingredient
    {
        public string text { get; set; }
        public float quantity { get; set; }
        public string measure { get; set; }
        public string food { get; set; }
        public float weight { get; set; }
        public string foodCategory { get; set; }
        public string foodId { get; set; }
        public string image { get; set; }
    }
}
