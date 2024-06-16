using MediatR;
using RecipesPlan.Core.Entities;

namespace RecipesPlan.Domain.UseCases.Commands.UpdateRecipesFromInternet
{
    public class UpdateRecipesFromInternetCommand : IRequest
    {
        public Filters Filter { get; set; }
    }
}
