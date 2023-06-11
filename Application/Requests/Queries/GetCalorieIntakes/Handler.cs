using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Queries.GetCalorieIntakes
{
    public partial class GetCalorieIntakes
    {
        public class Handler : IRequestHandler<Query, IEnumerable<CalorieIntake>>
        {
            private readonly I_DbContext _context;

            public Handler(I_DbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<CalorieIntake>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.CalorieIntakes.ToListAsync();
                return result;
            }
        }
    }
}
