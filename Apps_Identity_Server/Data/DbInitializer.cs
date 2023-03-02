using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apps_Identity_Server.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
