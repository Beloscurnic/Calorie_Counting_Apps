using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.List_Domain_Example
{
  public partial class List_Domain_Example
    {
        public class List_View_Model
        {
            public IList<List_Model> List_Models { get; set; }
        }
    }
}
