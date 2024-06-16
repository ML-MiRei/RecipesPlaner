using MediatR;
using RecipesPlan.Core.Entities;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Domain.UseCases.Commands.UpdateRecipe
{
    public class UpdateRecipeHandler(IRecipeRepository recipeRepository, IRecipesCash recipesCash) : IRequestHandler<UpdateRecipeCommand>
    {
        public Task Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                await recipeRepository.UpdateRecipe(request.recipeEntity);
                RecipeEntity recipe = recipesCash.SavedRecipes.First(r => r.Id == request.recipeEntity.Id);
                recipesCash.SavedRecipes[recipesCash.SavedRecipes.IndexOf(recipe)] = request.recipeEntity;
            });
        }
    }
}
