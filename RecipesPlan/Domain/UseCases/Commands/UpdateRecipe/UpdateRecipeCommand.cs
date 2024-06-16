using MediatR;
using RecipesPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Domain.UseCases.Commands.UpdateRecipe
{
    public class UpdateRecipeCommand : IRequest
    {
        public RecipeEntity recipeEntity {  get; set; }
    }
}
