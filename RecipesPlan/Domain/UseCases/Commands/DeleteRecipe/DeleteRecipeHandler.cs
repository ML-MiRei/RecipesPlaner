using MediatR;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.Interfaces.Repository;

namespace RecipesPlan.Domain.UseCases.Commands.DeleteRecipe
{
    public class DeleteRecipeHandler(IRecipesCash recipesCash, IRecipeRepository recipeRepository) : IRequestHandler<DeleteRecipeCommand>
    {
        public Task Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                recipeRepository.DeleteRecipe(request.Id);
                recipesCash.SavedRecipes.Remove(recipesCash.SavedRecipes.First(r => r.Id == request.Id));
            });
        }
    }
}
