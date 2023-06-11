using Application.Common.Exceptions;
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
    public class GetCalorieIntakesByDateQuery : IRequest<IEnumerable<CalorieIntake>>
    {
        public DateTime Start { get; }
        public DateTime Stop { get; }

        public GetCalorieIntakesByDateQuery(DateTime start, DateTime stop)
        {
            Start = start;
            Stop = stop;
        }
    }

    public class GetCalorieIntakesQueryByDateHandler : IRequestHandler<GetCalorieIntakesByDateQuery, IEnumerable<CalorieIntake>>
    {
        private readonly Apps_DbContext _context;

        public GetCalorieIntakesQueryByDateHandler(Apps_DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CalorieIntake>> Handle(GetCalorieIntakesByDateQuery request, CancellationToken cancellationToken)
        {
            var calorieIntakes = await _context.CalorieIntakes
                .Where(x => x.Date >= request.Start && x.Date <= request.Stop)
                .ToListAsync();

            if (calorieIntakes.Count == 0)
            {
                return Enumerable.Empty<CalorieIntake>();
            }

            return calorieIntakes;
        }
    }

}
