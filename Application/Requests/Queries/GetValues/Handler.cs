using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Queries.GetValues
{
    public partial class GetValues
    {
        public class Handler : IRequestHandler<Query, IEnumerable<CalorieIntake>>
        {
            public async Task<IEnumerable<CalorieIntake>> Handle(Query request, CancellationToken cancellationToken)
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
}
