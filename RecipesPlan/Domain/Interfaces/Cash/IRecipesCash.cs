using RecipesPlan.Core.Entities;
using System.Collections.ObjectModel;

namespace RecipesPlan.Domain.Interfaces.Cash
{
    public interface IRecipesCash
    {
        public ObservableCollection<RecipeEntity> SavedRecipes { get; set; }
        public ObservableCollection<RecipeEntity> SearchedRecipes { get; set; }
        public ObservableCollection<MenuEntity> Menus { get; set; }
        public event EventHandler MenuChanged;
        public void AddRecipeInMenu(int recipeId, DateTime date);
        public void DeleteRecipeFromMenu(int recipeId, DateTime date);


    }
}
