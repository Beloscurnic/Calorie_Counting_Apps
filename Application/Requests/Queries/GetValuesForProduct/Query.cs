using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.GetValuesForProduct
{
    public partial class GetValuesForProduct
    {
        public class Query : IRequest<CalorieIntake>
        {
            public FoodProduct Product { get; }

            public Query(FoodProduct product)
            {
                Product = product;
            }
        }
    }
}
