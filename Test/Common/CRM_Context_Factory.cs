using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
 public class CRM_Context_Factory
    {
        public static Guid Id_1 = Guid.NewGuid();
        public static Guid Id_2 = Guid.NewGuid();


        public static Apps_DbContext Create()
        {
            var options = new DbContextOptionsBuilder<Apps_DbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new Apps_DbContext(options);
            context.Database.EnsureCreated();
            context.Domain_Examples.AddRange(
                new Domain_Example
                {
                    Id = Id_1,
                    Name ="Dan",
                    Email="email@mail.ru"
                },
                new Domain_Example
                {
                    Id = Id_2,
                    Name = "Dan2",
                    Email = "email@mail.ru"
                }
                );
            context.SaveChanges();
            return context;
        }
        public static void Destroy(Apps_DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
