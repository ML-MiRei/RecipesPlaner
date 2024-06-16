using MediatR;

namespace RecipesPlan.Domain.UseCases.Commands.DeleteRecipe
{
    public class DeleteRecipeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
