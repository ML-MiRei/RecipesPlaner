using MediatR;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Domain.UseCases.Commands.AddInMenuRecipe
{
    public class AddInMenuRecipeHandler(IRecipeRepository recipeRepository, IRecipesCash recipesCash) : IRequestHandler<AddInMenuRecipeCommand>
    {
        public Task Handle(AddInMenuRecipeCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                recipeRepository.AddInMenuRecipe(request.Id, request.Date);
                recipesCash.AddRecipeInMenu(request.Id, request.Date);
            });
        }
    }
}
