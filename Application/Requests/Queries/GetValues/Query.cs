using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.GetValues
{
    public partial class GetValues
    {
        public class Query : IRequest<IEnumerable<CalorieIntake>>
        {
        }
    }
}
