using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Core.Entities
{
    public class Filters
    {
        public List<string> Healths { get; set; }
        public string Diet { get; set; }
        public string MealType { get; set; }
        public List<string> DishTypes { get; set; }
        public string Label { get; set; }
        public double? MaxCalories { get; set; }
        public double? MinCalories { get; set; }
        public string CaloriesRange {  get; set; }
    }
}
