using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Commands
{
    public class DeleteCalorieIntakeCommand : IRequest
    {
        public Guid Id { get; }

        public DeleteCalorieIntakeCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteCalorieIntakeCommandHandler : IRequestHandler<DeleteCalorieIntakeCommand>
    {
        private readonly I_DbContext _context;

        public DeleteCalorieIntakeCommandHandler(I_DbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCalorieIntakeCommand request, CancellationToken cancellationToken)
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
