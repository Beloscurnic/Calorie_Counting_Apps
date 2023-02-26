using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.List_Domain_Example
{
    public partial class List_Domain_Example
    {
        public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {

            }
        }
    }
}
