using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.DeleteCalorieIntake
{
    public partial class DeleteCalorieIntake
    {
        public class Command :IRequest
        {
            public Guid Id { get; }
            public Command(Guid id)
            {
                Id = id;
            }
        }
    }
}
