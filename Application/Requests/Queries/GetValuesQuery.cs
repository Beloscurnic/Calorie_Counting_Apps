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
    public class GetValuesQuery : IRequest<IEnumerable<CalorieIntake>>
    {
    }

    public class GetValuesQueryHandler : IRequestHandler<GetValuesQuery, IEnumerable<CalorieIntake>>
    {
        public async Task<IEnumerable<CalorieIntake>> Handle(GetValuesQuery request, CancellationToken cancellationToken)
        {
            List<CalorieIntake> calorieIntakes = new List<CalorieIntake>();
            foreach (FoodProduct product in Enum.GetValues(typeof(FoodProduct)))
            {
                calorieIntakes.Add(new CalorieIntake(product, 100));
            }
            return calorieIntakes;
        }
    }
}
