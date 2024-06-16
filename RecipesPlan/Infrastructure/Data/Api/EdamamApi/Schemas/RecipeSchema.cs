namespace RecipesPlan.Infrastructure.Data.Api.EdamamApi.Schemas
{
    public class Hit
    {
        public Recipe recipe { get; set; }
    }

    public class Recipe
    {
        [Newtonsoft.Json.JsonProperty("shareAs")]
        public string Share { get; set; }

        [Newtonsoft.Json.JsonProperty("label")]
        public string Label { get; set; }

        [Newtonsoft.Json.JsonProperty("image")]
        public string Image { get; set; }

        [Newtonsoft.Json.JsonProperty("healthLabels")]
        public string[] HealthLabels { get; set; }

        [Newtonsoft.Json.JsonProperty("ingredientLines")]
        public string[] IngredientLines { get; set; }    
        
        [Newtonsoft.Json.JsonProperty("cuisineType")]
        public string[] CuisineType { get; set; }        
        
        [Newtonsoft.Json.JsonProperty("mealType")]
        public string[] MealType { get; set; }

        [Newtonsoft.Json.JsonProperty("ingredients")]
        public Ingredient[] Ingredients { get; set; }

        [Newtonsoft.Json.JsonProperty("calories")]
        public float Calories { get; set; }

        [Newtonsoft.Json.JsonProperty("yield")]
        public float Yield { get; set; }

    }

}
