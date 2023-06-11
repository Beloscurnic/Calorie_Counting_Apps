using MediatR;
using System;

namespace Application.Requests.Commands.UpdateCalorieIntake
{
    public partial class UpdateCalorieIntake
    {
        public class Command : IRequest
        {
            public Guid Id { get; }
            public string FoodProduct { get; }
            public int Weight { get; }

            public Command(Guid id, string foodProduct, int weight)
            {
                Id = id;
                FoodProduct = foodProduct;
                Weight = weight;
            }
        }
    }
}
