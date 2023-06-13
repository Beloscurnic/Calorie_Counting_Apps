using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Commands.CreateCalorieIntake
{
    public partial class CreateCalorieIntake
    {
        public class Handler : IRequestHandler<Command, CalorieIntake>
        {
            private readonly I_DbContext _context;
            public Handler(I_DbContext dbContext) =>
            _context = dbContext;

            public async Task<CalorieIntake> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!Enum.TryParse(request.FoodProduct, out FoodProduct selectedProduct))
                {
                    return null;
                }
                var calorieIntake = new CalorieIntake(selectedProduct, request.Weight, request.UserId);
                await _context.CalorieIntakes.AddAsync(calorieIntake);
                await _context.SaveChangesAsync(CancellationToken.None);

                return calorieIntake;
            }
        }
    }
}

