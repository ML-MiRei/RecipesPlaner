using CommunityToolkit.Mvvm.ComponentModel;
using MediatR;
using Plugin.Maui.Calendar.Models;
using RecipesPlan.Core.Entities;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.UseCases;
using RecipesPlan.Domain.UseCases.Commands.DeleteFromMenuRecipe;
using RecipesPlan.Presentation.Cash;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Presentation.Modules.Schedule.ViewModel
{
    public partial class SchedulePageVM : ObservableObject
    {
        private static IMediator _mediator;
        private static IRecipesCash _recipesCash;


        [ObservableProperty]
        private static EventCollection recipesCalendarPlan;

        public SchedulePageVM(IRecipesCash recipesCash, IMediator mediator)
        {
            _mediator = mediator;
            _recipesCash = recipesCash;

            recipesCalendarPlan = new EventCollection();
            recipesCash.MenuChanged += OnMenuChanged; ;

            foreach (var menu in recipesCash.Menus)
            {
                recipesCalendarPlan[menu.Date] = menu.Recipes;
            }

        }

        private void OnMenuChanged(object? sender, EventArgs e)
        {
            recipesCalendarPlan[(DateTime)sender] = _recipesCash.Menus.First(m => m.Date == (DateTime)sender).Recipes;
        }

      
        public Command DeleteRecipeCommand { get; set; } = new Command(async (recipe) =>
        {
            await _mediator.Send(new DeleteFromMenuRecipeCommand
            {
                Id = ((RecipeEntity)recipe).Id.Value,
                Date = ((RecipeEntity)recipe).Date.Value
            });
            ((List<RecipeEntity>)recipesCalendarPlan[((RecipeEntity)recipe).Date.Value]).Remove((RecipeEntity)recipe);
        });
    }


}
