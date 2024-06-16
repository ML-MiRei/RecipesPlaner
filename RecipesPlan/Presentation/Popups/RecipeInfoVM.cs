using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using RecipesPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Presentation.Popups
{
    public partial class RecipeInfoVM : ObservableObject
    {
        public RecipeInfoVM(RecipeEntity recipeEntity = null)
        {
            if (recipeEntity != null)
            {
                IngredientsNames = new ObservableCollection<string>(recipeEntity.IngredientsNames);
                Label = recipeEntity.Label;
                Note = recipeEntity.Note;
                Calories = recipeEntity.Calories.Value;
                Yield = recipeEntity.Yield.Value;
                Id = recipeEntity.Id;
            }

            AddIngredient = new Command(async () =>
            {
                string result = (string)await Shell.Current.CurrentPage.ShowPopupAsync(new InputPopup());
                if (result != null)
                    IngredientsNames.Add(result);
            });


            DeleteIngredient = new Command((name) =>
            {
                IngredientsNames.Remove((string)name);
            });

           
        }

        [ObservableProperty]
        private ObservableCollection<string> ingredientsNames = new ObservableCollection<string>();

        [ObservableProperty]
        private string label = "";

        [ObservableProperty]
        private string note = "";

        [ObservableProperty]
        private double calories = 0;

        [ObservableProperty]
        private int? id = null;

        [ObservableProperty]
        private double yield = 0;


        public Command AddIngredient { get; set; }
        public Command DeleteIngredient { get; set; }

        public RecipeEntity RecipeEntity => new RecipeEntity
        {
            Calories = calories,
            Label = label,
            Note = note,
            Id = id,
            IngredientsNames = IngredientsNames.ToList(),
            Yield = yield
        };
    }
}
