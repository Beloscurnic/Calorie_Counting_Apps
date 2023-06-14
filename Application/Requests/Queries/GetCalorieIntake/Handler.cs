using Application.Interfaces;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Queries.GetCalorieIntake
{
    public partial class GetCalorieIntake
    {
        public class Handler : IRequestHandler<Query, CalorieIntake>
        {
            private readonly I_DbContext _context;

            public Handler(I_DbContext dbContext)
            {
                _context = dbContext;
            }

            public async Task<CalorieIntake> Handle(Query request, CancellationToken cancellationToken)
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
}