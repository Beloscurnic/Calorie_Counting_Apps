using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Queries.GetValuesForProduct
{
    public partial class GetValuesForProduct
    {
        public class Handler : IRequestHandler<Query, CalorieIntake>
        {
            public async Task<CalorieIntake> Handle(Query request, CancellationToken cancellationToken)
            {
                var calorieIntake = new CalorieIntake(request.Product, 100);
                return calorieIntake;
            }
        }
    }
}
