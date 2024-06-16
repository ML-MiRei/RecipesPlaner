using RecipesPlan.Core.Entities;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.Interfaces.Repository;
using RecipesPlan.Domain.UseCases;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecipesPlan.Presentation.Cash
{
    public class RecipesCash : IRecipesCash
    {
        public event EventHandler MenuChanged;
        private static Random rand = new Random();
        private Task task;


        public RecipesCash(IRecipeRepository recipeRepository)
        {
            SavedRecipes = new ObservableCollection<RecipeEntity>(recipeRepository.GetSavedRecipes().Result);
            Menus = new ObservableCollection<MenuEntity>(recipeRepository.GetMenus().Result);

            task = new Task(async () =>
            {
                var reply = recipeRepository.GetRecipes(new Filters() { Label = (char)rand.Next('a', 'z' + 1) + "" });
                _searchedRecipes = new ObservableCollection<RecipeEntity>(await reply);
            });
            task.Start();
        }





        public ObservableCollection<RecipeEntity> SavedRecipes { get; set; }

        private ObservableCollection<RecipeEntity> _searchedRecipes;
        public ObservableCollection<RecipeEntity> SearchedRecipes
        {
            get
            {
                if (_searchedRecipes == null)
                {
                    if (!task.IsCompletedSuccessfully)
                        task.Wait();
                }
                return _searchedRecipes;
            }
            set
            {
                _searchedRecipes = value;
            }
        }

        private ObservableCollection<MenuEntity> _menus;
        public ObservableCollection<MenuEntity> Menus
        {
            get
            {
                return _menus;
            }
            set
            {
                _menus = value;
            }
        }

        public void AddRecipeInMenu(int recepiId, DateTime date)
        {
            RecipeEntity recipe = SavedRecipes.First(r => r.Id == recepiId);
            try
            {
                Menus.First(m => m.Date == date).Recipes.Add(recipe);
            }
            catch (Exception)
            {
                Menus.Add(new MenuEntity { Date = date, Recipes = new List<RecipeEntity>() { recipe } });
            }
            finally
            {
                recipe.Date = date;
                MenuChanged?.Invoke(date, EventArgs.Empty);
            }
        }

        public void DeleteRecipeFromMenu(int recepiId, DateTime date)
        {
            RecipeEntity recipe = SavedRecipes.First(r => r.Id == recepiId);

            Menus.First(m => m.Date == date).Recipes.Remove(recipe);
            if (Menus.Where(m => m.Date == date).Count() == 0)
                Menus.Remove(new MenuEntity { Date = date, Recipes = new List<RecipeEntity>() });

            MenuChanged?.Invoke(date, EventArgs.Empty);

        }

    }
}
