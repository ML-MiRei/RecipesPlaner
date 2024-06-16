using MediatR;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Domain.UseCases.Commands.DeleteFromMenuRecipe
{
    public class DeleteFromMenuRecipeHandler(IRecipeRepository recipeRepository, IRecipesCash recipesCash) : IRequestHandler<DeleteFromMenuRecipeCommand>
    {
        public Task Handle(DeleteFromMenuRecipeCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                recipeRepository.DeleteFromMenuRecipe(request.Id, request.Date);
                recipesCash.DeleteRecipeFromMenu(request.Id, request.Date);
            });
        }
    }
}
