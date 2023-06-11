using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Queries.GetCalorieIntakesByDate
{
    public partial class GetCalorieIntakesByDate
    {
        public class Handler : IRequestHandler<Query, List<CalorieIntake>>
        {
            private readonly I_DbContext _context;

            public Handler(I_DbContext context)
            {
                _context = context;
            }
            public async Task<List<CalorieIntake>> Handle(Query request, CancellationToken cancellationToken)
            {
                var calorieIntakes = await _context.CalorieIntakes
                    .Where(x => x.Date >= request.Start && x.Date <= request.Stop)
                    .ToListAsync();

                if (calorieIntakes.Count == 0)
                {
                    return Enumerable.Empty<CalorieIntake>().ToList();
                }
                return calorieIntakes;
            }
        }
    }
}
