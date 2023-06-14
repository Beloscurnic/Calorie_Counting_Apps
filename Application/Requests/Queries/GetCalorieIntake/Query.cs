using Domain;
using MediatR;
using System;

namespace Application.Requests.Queries.GetCalorieIntake
{
    public partial class GetCalorieIntake
    {
        public class Query:IRequest<CalorieIntake>
        {
            public Guid Id { get; }
            public Guid UserId { get; }

            public Query(Guid id, Guid userId)
            {
                Id = id;
                UserId = userId;
            }
        }
    }
}
