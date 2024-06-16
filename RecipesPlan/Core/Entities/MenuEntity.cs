using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Core.Entities
{
    public class MenuEntity
    {
        public DateTime Date {  get; set; }
        public List<RecipeEntity> Recipes { get; set; }
    }
}
