using Application.Common.Exceptions;
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
    public class UpdateCalorieIntakeCommand : IRequest
    {
        public Guid Id { get; }
        public string FoodProduct { get; }
        public int Weight { get; }

        public UpdateCalorieIntakeCommand(Guid id, string foodProduct, int weight)
        {
            Id = id;
            FoodProduct = foodProduct;
            Weight = weight;
        }
    }

    public class UpdateCalorieIntakeCommandHandler : IRequestHandler<UpdateCalorieIntakeCommand>
    {
        private readonly I_DbContext _context;

        public UpdateCalorieIntakeCommandHandler(I_DbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCalorieIntakeCommand request, CancellationToken cancellationToken)
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
