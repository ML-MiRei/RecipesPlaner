using MediatR;

namespace RecipesPlan.Domain.UseCases.Commands.DeleteFromMenuRecipe
{
    public class DeleteFromMenuRecipeCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
