using RecipesPlan.Core.Entities;
using RecipesPlan.Infrastructure.Data.Api.EdamamApi.Schemas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Domain.Interfaces.Repository
{
    public interface IRecipeRepository
    {
        Task<List<RecipeEntity>> GetRecipes(Filters searchOptions);
        Task<List<RecipeEntity>> GetSavedRecipes();
        Task<List<MenuEntity>> GetMenus();
        Task DeleteRecipe(int id);
        Task DeleteFromMenuRecipe(int id, DateTime date);
        Task<RecipeEntity> SaveRecipe(RecipeEntity recipe);
        Task UpdateRecipe(RecipeEntity recipe);
        Task AddInMenuRecipe(int id, DateTime date);


    }
}
