using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Commands
{
    public class CreateCalorieIntakeCommand : IRequest<CalorieIntake>
    {
        public string FoodProduct { get; }
        public int Weight { get; }

        public CreateCalorieIntakeCommand(string foodProduct, int weight)
        {
            FoodProduct = foodProduct;
            Weight = weight;
        }
    }

    public class CreateCalorieIntakeCommandHandler : IRequestHandler<CreateCalorieIntakeCommand, CalorieIntake>
    {
        private readonly I_DbContext _context;

        public CreateCalorieIntakeCommandHandler(I_DbContext context)
        {
            _context = context;
        }

        public async Task<CalorieIntake> Handle(CreateCalorieIntakeCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse(request.FoodProduct, out FoodProduct selectedProduct))
            {
                return null;
            }

            var calorieIntake = new CalorieIntake(selectedProduct, request.Weight);
            await _context.CalorieIntakes.AddAsync(calorieIntake);
            await _context.SaveChangesAsync(CancellationToken.None);

            return calorieIntake;
        }
    }

}
