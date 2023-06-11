using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.CreateCalorieIntake
{
    public partial class CreateCalorieIntake
    {
        public class Command : IRequest<CalorieIntake>
        {
            public string FoodProduct { get; }
            public int Weight { get; }

            public Command(string foodProduct, int weight)
            {
                FoodProduct = foodProduct;
                Weight = weight;
            }
        }

    }
}
