using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesPlan.Core.Entities
{
    public class RecipeEntity
    {
        public int? Id { get; set; }
        public string? Label { get; set; }
        public string? UrlImage { get; set; }
        public double? Calories {  get; set; }
        public double? Yield {  get; set; }
        public string? Note { get; set; }
        public DateTime? Date { get; set; }
        public List<string> IngredientsNames { get; set; } = new List<string>();
        public List<string> HealthLabels { get; set; } = new List<string>();
        public string MealType { get; set; }
        public string CuisineType { get; set; }


    }
}
