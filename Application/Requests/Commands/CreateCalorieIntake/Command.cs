using Domain;
using MediatR;
using System;

namespace Application.Requests.Commands.CreateCalorieIntake
{
    public partial class CreateCalorieIntake
    {
        public class Command : IRequest<CalorieIntake>
        {
            public string FoodProduct { get; }
            public int Weight { get; }
            public Guid UserId { get; }

            public Command(string foodProduct, int weight, Guid userId)
            {
                FoodProduct = foodProduct;

                Weight = weight;

                UserId = userId;
            }
        }

    }
}
