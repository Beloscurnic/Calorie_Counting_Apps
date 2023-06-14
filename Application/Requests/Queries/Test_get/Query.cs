using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Test_get
{
    public partial class Test_get
    {
        public class Query: IRequest<List_View_Model_Test>
        {

        }
    }
}
