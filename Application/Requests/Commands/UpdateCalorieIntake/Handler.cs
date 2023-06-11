using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Commands.UpdateCalorieIntake
{
    public partial class UpdateCalorieIntake
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly I_DbContext _context;
            public Handler(I_DbContext dbContext) => _context = dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var calorieIntake = await _context.CalorieIntakes.FindAsync(request.Id);

                if (calorieIntake == null)
                {
                    throw new Exception();
                }

                if (!Enum.TryParse(request.FoodProduct, out FoodProduct selectedProduct))
                {
                    throw new Exception("Invalid food product.");
                }

                calorieIntake.Product = selectedProduct;
                calorieIntake.Weight = request.Weight;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
        }
    }
}
