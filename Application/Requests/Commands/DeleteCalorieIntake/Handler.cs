using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Commands.DeleteCalorieIntake
{
    public partial class DeleteCalorieIntake
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
                _context.CalorieIntakes.Remove(calorieIntake);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
