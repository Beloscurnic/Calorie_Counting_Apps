using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.GetCalorieIntakesByDate
{
    public partial class GetCalorieIntakesByDate
    {
        public class Query: IRequest<List<CalorieIntake>>
        {
            public DateTime Start { get; }
            public DateTime Stop { get; }

            public Query(DateTime start, DateTime stop)
            {
                Start = start;
                Stop = stop;
            }
        }
    }
}
