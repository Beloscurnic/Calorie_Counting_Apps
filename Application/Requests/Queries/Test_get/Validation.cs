using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Test_get
{
    public partial class Test_get
    {
        public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {

            }
        }
    }
}
