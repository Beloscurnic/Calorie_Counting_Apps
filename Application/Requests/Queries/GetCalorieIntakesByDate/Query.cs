using Domain;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Requests.Queries.GetCalorieIntakesByDate
{
    public partial class GetCalorieIntakesByDate
    {
        public class Query: IRequest<List<CalorieIntake>>
        {
            public DateTime Start { get; }
            public DateTime Stop { get; }
            public Guid UserId { get; set; } 

            public Query(DateTime start, DateTime stop, Guid userId)
            {
                Start = start;
                Stop = stop;
                UserId = userId;
            }
        }
    }
}
