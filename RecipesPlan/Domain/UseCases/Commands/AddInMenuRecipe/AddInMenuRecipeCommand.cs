using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Domain.UseCases.Commands.AddInMenuRecipe
{
    public class AddInMenuRecipeCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
