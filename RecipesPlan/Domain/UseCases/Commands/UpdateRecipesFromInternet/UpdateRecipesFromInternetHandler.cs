using MediatR;
using RecipesPlan.Core.Entities;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.Interfaces.Repository;
using System.Collections.ObjectModel;

namespace RecipesPlan.Domain.UseCases.Commands.UpdateRecipesFromInternet
{
    public class UpdateRecipesFromInternetHandler(IRecipeRepository recipeRepository, IRecipesCash recipesCash) : IRequestHandler<UpdateRecipesFromInternetCommand>
    {
        public Task Handle(UpdateRecipesFromInternetCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var result = recipeRepository.GetRecipes(request.Filter).Result;
                recipesCash.SearchedRecipes = new ObservableCollection<RecipeEntity>(result);
            });
        }
    }
}
