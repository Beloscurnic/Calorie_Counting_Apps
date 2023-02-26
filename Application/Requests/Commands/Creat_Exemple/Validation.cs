using FluentValidation;

namespace Application.Requests.Commands.Creat_Exemple
{
   public partial class Creat_Exemple
    {
        public class Validation:AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(c => c.Name).NotEmpty();
            }
        }
    }
}
