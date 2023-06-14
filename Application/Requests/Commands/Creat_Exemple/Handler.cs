using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Creat_Exemple
{
    public partial class Creat_Exemple
    {
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly I_DbContext _dbContext;
            public Handler(I_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<int> Handle(Command request,
          CancellationToken cancellationToken)
            {
                var new_exemple = new Domain_Example
                {                  
                    Name = request.Name,
                    Email = request.Email
                };
                await _dbContext.Domain_Examples.AddAsync(new_exemple);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return new_exemple.Id;
            }
        }
    }
}
