using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using MediatR;
using RecipesPlan.Core.Entities;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.UseCases.Commands.AddInMenuRecipe;
using RecipesPlan.Domain.UseCases.Commands.DeleteRecipe;
using RecipesPlan.Domain.UseCases.Commands.SaveRecipe;
using RecipesPlan.Domain.UseCases.Commands.UpdateRecipe;
using RecipesPlan.Presentation.Popups;
using System.Collections.ObjectModel;

namespace RecipesPlan.Presentation.Modules.Main.ViewModel
{
    public partial class MainPageVM : ObservableObject
    {
        private static IMediator _mediator;
        public MainPageVM(IMediator mediator, IRecipesCash recipesCash)
        {
            _mediator = mediator;

            savedRecipes = recipesCash.SavedRecipes;

            //AddRecipeCommand = new Command(async () =>
            //{
            //    RecipeInfoPopup recipeInfoPopup = new RecipeInfoPopup();
            //    RecipeEntity result = (RecipeEntity)await Shell.Current.CurrentPage.ShowPopupAsync(recipeInfoPopup);

            //    if (result != null)
            //    {
            //        var recepi = await saveRecipeUseCase.Execute(result);
            //        SavedRecipes.Add(result);
            //    }
            //});

            //DeleteRecipeCommand = new Command(async (id) =>
            //{
            //    AlertPopup alertPopup = new AlertPopup();
            //    bool result = (bool)await Shell.Current.CurrentPage.ShowPopupAsync(alertPopup);

            //    if (result)
            //    {
            //        await deleteRecipeUseCase.Execute((int)id);
            //        SavedRecipes.Remove(SavedRecipes.First(r => r.Id == (int)id));
            //    }

            //});

            //InMenuRecipeCommand = new Command(async (id) =>
            //{
            //    AddInMenuPopup addInMenuPopup = new AddInMenuPopup();
            //    DateTime result = (DateTime)await Shell.Current.CurrentPage.ShowPopupAsync(addInMenuPopup);

            //    if (result != null)
            //    {
            //        await addInMenuRecipeUseCase.Execute((int)id, result);
            //        SavedRecipes.First(r => r.Id == (int)id).Date = result;
            //        schedulePageVM.AddRecipe(SavedRecipes.First(r => r.Id == (int)id));
            //    }

            //});

            //UpdateRecipeCommand = new Command(async (recipeEntity) =>
            //{
            //    RecipeInfoPopup recipeInfoPopup = new RecipeInfoPopup((RecipeEntity)recipeEntity);
            //    RecipeEntity result = (RecipeEntity)await Shell.Current.CurrentPage.ShowPopupAsync(recipeInfoPopup);

            //    if (result != null)
            //    {
            //        await updateRecipeUseCase.Execute(result);
            //        SavedRecipes[SavedRecipes.IndexOf(SavedRecipes.First(r => r.Id == ((RecipeEntity)recipeEntity).Id))] = result;
            //    }
            //});

        }


        [ObservableProperty]
        private ObservableCollection<RecipeEntity> savedRecipes;


        public Command AddRecipeCommand { get; set; } = new Command(async () =>
        {
            RecipeInfoPopup recipeInfoPopup = new RecipeInfoPopup();
            RecipeEntity result = (RecipeEntity)await Shell.Current.CurrentPage.ShowPopupAsync(recipeInfoPopup);

            if (result != null)
            {
                await _mediator.Send(new SaveRecipeCommand { recipeEntity = result });
            }
        });
        public Command DeleteRecipeCommand { get; set; } = new Command(async (id) =>
        {
            AlertPopup alertPopup = new AlertPopup();
            bool result = (bool)await Shell.Current.CurrentPage.ShowPopupAsync(alertPopup);

            if (result)
            {
                await _mediator.Send(new DeleteRecipeCommand { Id = (int)id });
            }

        });
        public Command UpdateRecipeCommand { get; set; } = new Command(async (recipeEntity) =>
        {
            RecipeInfoPopup recipeInfoPopup = new RecipeInfoPopup((RecipeEntity)recipeEntity);
            RecipeEntity result = (RecipeEntity)await Shell.Current.CurrentPage.ShowPopupAsync(recipeInfoPopup);

            if (result != null)
            {
                await _mediator.Send(new UpdateRecipeCommand { recipeEntity = result });
            }
        });
        public Command InMenuRecipeCommand { get; set; } = new Command(async (id) =>
        {
            AddInMenuPopup addInMenuPopup = new AddInMenuPopup();
            DateTime result = (DateTime)await Shell.Current.CurrentPage.ShowPopupAsync(addInMenuPopup);

            if (result != null)
            {
                await _mediator.Send(new AddInMenuRecipeCommand { Id = (int)id, Date = result });
            }

        });


    }
}
