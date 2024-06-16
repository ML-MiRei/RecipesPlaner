using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using MediatR;
using RecipesPlan.Core.Entities;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.UseCases;
using RecipesPlan.Domain.UseCases.Commands.SaveRecipe;
using RecipesPlan.Domain.UseCases.Commands.UpdateRecipesFromInternet;
using RecipesPlan.Presentation.Modules.Main.ViewModel;
using RecipesPlan.Presentation.Popups;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RecipesPlan.Presentation.Modules.Internet.ViewModel
{

    public partial class RecipesPageVM : ObservableObject
    {
        private static IMediator _mediator;
        private static IRecipesCash _recipesCash;
        private static Random _random = new Random();

        #region filters
        [ObservableProperty]
        private static List<string> diets = new List<string> { "balanced", "high-protein", "high-fiber", "low-fat", "low-carb", "low-sodium" };

        [ObservableProperty]
        private static List<string> healths = new List<string> { "alcohol-free", "celery-free", "crustacean-free", "dairy-free", "egg-free", "fish-free", "gluten-free", "immuno-supportive", "keto-friendly", "kidney-friendly", "low-potassium", "low-sugar", "lupine-free", "mollusk-free", "mustard-free", "No-oil-added", "peanut-free", "red-meat-free", "soy-free", "tree-nut-free", "vegan", "vegetarian", "wheat-free" };

        [ObservableProperty]
        private static List<string> mealTypes = new List<string> { "breakfast", "brunch", "lunch", "dinner", "snack", "teatime" };

        [ObservableProperty]
        private static List<string> dishTypes = new List<string> { "bread", "cereals", "desserts", "drinks", "egg", "pancake", "pasta", "pastry", "pizza", "preps", "preserve", "salad", "sandwiches", "seafood", "soup", "starter", "sweets" };
        #endregion

        #region selected filters
        [ObservableProperty]
        private static string selectedDiet;
        [ObservableProperty]
        private static List<string> selectedHealths;
        [ObservableProperty]
        private static List<string> selectedDishTypes;
        [ObservableProperty]
        private static string selectedMealType;
        [ObservableProperty]
        private static string searchLabel = "";
        #endregion

        [ObservableProperty]
        private static ObservableCollection<RecipeEntity> recipes;

        public RecipesPageVM(IMediator mediator, IRecipesCash recipesCash)
        {
            _mediator = mediator;
            _recipesCash = recipesCash;
            recipes = recipesCash.SearchedRecipes;

            ApplyFilter = new Command(async () =>
            {
                await _mediator.Send(new UpdateRecipesFromInternetCommand
                {
                    Filter = new Filters
                    {
                        Label = searchLabel == "" ? (char)_random.Next('a', 'z' + 1) + "" : searchLabel,
                        Diet = selectedDiet,
                        Healths = selectedHealths,
                        MealType = selectedMealType,
                        DishTypes = selectedDishTypes
                    }
                });

                recipes = _recipesCash.SearchedRecipes;
                OnPropertyChanged("Recipes");


            });
        }

        public Command ApplyFilter { get; set; } 
        public Command SaveRecipe { get; set; } = new Command(async (recipe) =>
        {
            bool result = (bool)await Shell.Current.CurrentPage.ShowPopupAsync(new AlertPopup(title: "Do you want to keep this recipe?", positiveButtonText: "Save"));
            if (result)
            {
                await _mediator.Send(new SaveRecipeCommand { recipeEntity = (RecipeEntity)recipe });
            }
        });
      
    }
}
