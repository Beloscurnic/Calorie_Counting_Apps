using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Queries
{
    public class GetCalorieIntakesQuery : IRequest<IEnumerable<CalorieIntake>>
    {
    }

    public class GetCalorieIntakesQueryHandler : IRequestHandler<GetCalorieIntakesQuery, IEnumerable<CalorieIntake>>
    {
        private readonly I_DbContext _context;

        public GetCalorieIntakesQueryHandler(I_DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CalorieIntake>> Handle(GetCalorieIntakesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.CalorieIntakes.ToListAsync();
            return result;
        }
    }

}
