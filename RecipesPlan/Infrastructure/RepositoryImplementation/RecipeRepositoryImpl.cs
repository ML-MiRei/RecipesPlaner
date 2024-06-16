using RecipesPlan.Core.Entities;
using RecipesPlan.Core.Exceptions;
using RecipesPlan.Data.Api.EdamamApi;
using RecipesPlan.Domain.Interfaces.Repository;
using RecipesPlan.Infrastructure.Data.Api.EdamamApi;
using RecipesPlan.Infrastructure.Data.Database.Context;
using RecipesPlan.Infrastructure.Data.Database.Model;
using System.Net.Http.Json;

namespace RecipesPlan.Infrastructure.RepositoryImplementation
{
    public class RecipeRepositoryImpl(ILocalDbService db) : IRecipeRepository
    {
        HttpClient httpClient = EdamamHttpClient.GetHttpClient();

        public async Task AddInMenuRecipe(int id, DateTime date)
        {
            await db.Connection.InsertAsync(new Menu { Date = date, RecipeId = id });
        }

        public async Task DeleteFromMenuRecipe(int id, DateTime date)
        {
            Menu menu = await db.Connection.Table<Menu>().FirstAsync(m => m.Id == id && m.Date == date);
            await db.Connection.DeleteAsync(menu);
        }

        public async Task DeleteRecipe(int id)
        {
            Recipe recipe = db.Connection.Table<Recipe>().FirstAsync(r => r.Id == id).Result;
            var ing = db.Connection.Table<Ingredient>().ToListAsync().Result.Where(r => r.RecipeId == id);

            await db.Connection.DeleteAsync(recipe);
            await db.Connection.DeleteAsync(ing);
        }

        public async Task<List<MenuEntity>> GetMenus()
        {
            var menu = db.Connection.Table<Menu>().ToListAsync().Result;
            return menu.Select(m => new MenuEntity
            {
                Date = m.Date,
                Recipes = db.Connection.Table<Recipe>().ToListAsync().Result.Select(r => new RecipeEntity
                {
                    Calories = r.Calories,
                    Date = m.Date,
                    Id = r.Id,
                    Label = r.Label,
                    Note = r.Note,
                    Yield = r.Portions,
                    IngredientsNames = db.Connection.Table<Ingredient>().Where(i => i.RecipeId == r.Id).ToListAsync().Result
                                .Select(i => i.Line).ToList()
                }).ToList()
            }).ToList();
        }

        public async Task<List<RecipeEntity>> GetRecipes(Filters searchOptions)
        {
            var httpReply = httpClient.GetAsync(RecipeSearchRequest.Create(searchOptions)).Result;
            if (httpReply.IsSuccessStatusCode)
            {
                return (await httpReply.Content.ReadFromJsonAsync<Data.Api.EdamamApi.Schemas.ReplyShema>()).Hits.Select(h => h.recipe).Select(r => new RecipeEntity
                {
                    Calories = Math.Round(r.Calories, 2),
                    Yield = r.Yield,
                    UrlImage = r.Image,
                    Label = r.Label,
                    IngredientsNames = r.IngredientLines.ToList(),
                    HealthLabels = r.HealthLabels.ToList(),
                    CuisineType = r.CuisineType.Length != 0 ? r.CuisineType[0] : null,
                    MealType = r.MealType.Length != 0 ? r.MealType[0] : null
                }).ToList();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public async Task<List<RecipeEntity>> GetSavedRecipes()
        {

            var result = db.Connection.Table<Recipe>().ToListAsync().Result;
            return result.Select(r => new RecipeEntity
            {
                Calories = r.Calories,
                Date = r.Date,
                Id = r.Id,
                Label = r.Label,
                Note = r.Note,
                Yield = r.Portions,
                IngredientsNames = db.Connection.Table<Ingredient>().Where(i => i.RecipeId == r.Id).ToListAsync().Result
                                .Select(i => i.Line).ToList()
            }).ToList();

        }

        public async Task<RecipeEntity> SaveRecipe(RecipeEntity recipeEntity)
        {
            Recipe recipe = new Recipe()
            {
                Calories = recipeEntity.Calories.Value,
                Portions = recipeEntity.Yield.Value,
                Date = recipeEntity.Date,
                Label = recipeEntity.Label,
                Note = recipeEntity.Note,
            };
            await db.Connection.InsertAsync(recipe);

            List<Ingredient> ingredients = recipeEntity.IngredientsNames
                .Select(i => new Ingredient() { Line = i, RecipeId = recipe.Id }).ToList();
            await db.Connection.InsertAllAsync(ingredients);

            recipeEntity.Id = recipe.Id;
            return recipeEntity;
        }

        public async Task UpdateRecipe(RecipeEntity recipeEntity)
        {
            Recipe recipe = db.Connection.Table<Recipe>().FirstAsync(r => r.Id == recipeEntity.Id).Result;

            recipe.Note = recipeEntity.Note;
            recipe.Date = recipeEntity.Date;
            recipe.Label = recipeEntity.Label;
            recipe.Calories = recipeEntity.Calories.Value;
            recipe.Portions = recipeEntity.Yield.Value;

            var ingredientsInDb = db.Connection.Table<Ingredient>().Where(i => i.RecipeId == recipe.Id).ToListAsync().Result;

            for (int i = 0; i < ingredientsInDb.Count; i++)
            {
                if (!recipeEntity.IngredientsNames.Contains(ingredientsInDb[i].Line))
                {
                    var ing = db.Connection.Table<Ingredient>().ToListAsync().Result;
                    Ingredient ingredient = db.Connection.Table<Ingredient>().Where(g => g.RecipeId == recipeEntity.Id && g.Line == ingredientsInDb[i].Line).ToListAsync().Result[0];
                    await db.Connection.DeleteAsync(ingredient);
                }
            }

            for (int i = 0; i < recipeEntity.IngredientsNames.Count; i++)
            {
                if (ingredientsInDb.Where(ingr => ingr.Line == recipeEntity.IngredientsNames[i]).Count() == 0)
                {
                    Ingredient ingredient = new Ingredient { Line = recipeEntity.IngredientsNames[i], RecipeId = recipeEntity.Id.Value };
                    await db.Connection.InsertAsync(ingredient);
                }
            }

            await db.Connection.UpdateAsync(recipe);
        }
    }
}
