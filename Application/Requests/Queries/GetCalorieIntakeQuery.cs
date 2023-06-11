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

namespace Application.Requests.Queries
{
    public class GetCalorieIntakeQuery : IRequest<CalorieIntake>
    {
        public Guid Id { get; }

        public GetCalorieIntakeQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetCalorieIntakeQueryHandler : IRequestHandler<GetCalorieIntakeQuery, CalorieIntake>
    {
        private readonly I_DbContext _context;

        public GetCalorieIntakeQueryHandler(I_DbContext context)
        {
            _context = context;
        }

        public async Task<CalorieIntake> Handle(GetCalorieIntakeQuery request, CancellationToken cancellationToken)
        {
            var calorieIntake = await _context.CalorieIntakes.FindAsync(request.Id);

            if (calorieIntake == null)
            {
                return null;
            }

            return calorieIntake;
        }
    }

}
