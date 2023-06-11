using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.CreateCalorieIntake
{
    public partial class CreateCalorieIntake
    {
       public class Validation : AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(c => c.FoodProduct).NotEmpty();
            }
        }
    }
}
