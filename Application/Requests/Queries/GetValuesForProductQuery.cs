using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Queries
{
    public class GetValuesForProductQuery : IRequest<CalorieIntake>
    {
        public FoodProduct Product { get; }

        public GetValuesForProductQuery(FoodProduct product)
        {
            Product = product;
        }
    }

    public class GetValuesForProductQueryHandler : IRequestHandler<GetValuesForProductQuery, CalorieIntake>
    {
        public async Task<CalorieIntake> Handle(GetValuesForProductQuery request, CancellationToken cancellationToken)
        {
            var calorieIntake = new CalorieIntake(request.Product, 100);
            return calorieIntake;
        }
    }

}
