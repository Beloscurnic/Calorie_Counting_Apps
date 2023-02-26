using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbIntializer
    {
        public static void Initialize(Apps_DbContext context)
        {
          
            context.Database.EnsureCreated();
        }
    }
}
