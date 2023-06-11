using Domain;
using MediatR;
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
        private readonly Apps_DbContext _context;

        public GetCalorieIntakesQueryHandler(Apps_DbContext context)
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
