using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Creat_Exemple
{
    public partial class Creat_Exemple
    {
        public class Command:IRequest<int>
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
