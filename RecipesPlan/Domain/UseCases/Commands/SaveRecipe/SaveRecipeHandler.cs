using MediatR;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Domain.UseCases.Commands.SaveRecipe
{
    public class SaveRecipeHandler(IRecipeRepository recipeRepository, IRecipesCash recipesCash) : IRequestHandler<SaveRecipeCommand>
    {
        public Task Handle(SaveRecipeCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                var result = await recipeRepository.SaveRecipe(request.recipeEntity);
                recipesCash.SavedRecipes.Add(result);
            });
        }
    }
}
