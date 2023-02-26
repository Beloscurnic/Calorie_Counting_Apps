using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Requests.Queries.List_Domain_Example
{
    public partial class List_Domain_Example
    {
        public class Handler : IRequestHandler<Query, List_View_Model>
        {
            private readonly I_DbContext _DbContext;
            private readonly IMapper _mapper;

            public Handler(I_DbContext dbContext, IMapper mapper)
            {
                _DbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List_View_Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Domain_Examples
                    .ProjectTo<List_Model>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return new List_View_Model { List_Models= entity };
            }
        }
    }
}
