using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.GetCalorieIntake
{
    public partial class GetCalorieIntake
    {
        public class Query:IRequest<CalorieIntake>
        {
            public Guid Id { get; }

            public Query(Guid id)
            {
                Id = id;
            }
        }
    }
}
