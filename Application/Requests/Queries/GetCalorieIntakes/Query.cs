using Domain;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Requests.Queries.GetCalorieIntakes
{
    public partial class GetCalorieIntakes
    {
       
        public class Query : IRequest<IEnumerable<CalorieIntake>>
        {
            public Guid UserId { get; set; }

            public Query(Guid userId)
            {
                UserId = userId;
            }
        }
    }
}
