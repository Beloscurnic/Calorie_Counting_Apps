using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Requests.Queries.Test_get
{
    public partial class Test_get
    {
        public class Handler : IRequestHandler<Query, List_View_Model_Test>
        {
            private readonly I_DbContext _DbContext;
            private readonly IMapper _mapper;

            public Handler(I_DbContext dbContext, IMapper mapper)
            {
                _DbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List_View_Model_Test> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Domain_Examples                  
                    .Select(p => new List_Model_Test
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Email = p.Email
                    })
                    .ToListAsync(cancellationToken);

                return new List_View_Model_Test { List_Models= entity };
            }
        }
    }
}
