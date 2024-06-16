using Microsoft.Extensions.Primitives;
using RecipesPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RecipesPlan.Infrastructure.Data.Api.EdamamApi
{
    public class RecipeSearchRequest
    {
        private const string BASE_REQUEST = "https://api.edamam.com/api/recipes/v2?type=public";
        private const string USER_DATA = "&app_id=8fddd608&app_key=%20d213ce530ab7947835b633b1f39d46d4";


        public static string Create(Filters searchOptions)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(BASE_REQUEST);

            sb.Append("&q=" + searchOptions.Label);

            sb.Append(USER_DATA);

            if (!String.IsNullOrEmpty(searchOptions.Diet))
                sb.Append("&diet=" + searchOptions.Diet);

            if (searchOptions.Healths != null && searchOptions.Healths.Count > 0)
            {
                foreach (var health in searchOptions.Healths)
                {
                    sb.Append("&health=" + health);
                }
            }

            if (!String.IsNullOrEmpty(searchOptions.MealType))
                sb.Append("&mealType=" + searchOptions.MealType);

            if (searchOptions.DishTypes != null && searchOptions.DishTypes.Count > 0)
            {
                foreach (var health in searchOptions.DishTypes)
                {
                    sb.Append("&dishType=" + health);
                }
            }

            sb.Append("&imageSize=REGULAR");

            return sb.ToString();
        }

    }
}
