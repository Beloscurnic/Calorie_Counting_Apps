using Application.Requests.Commands.Creat_Exemple;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Test.Common;
using Xunit;

namespace Test.Requests.Commands
{
    public class Creat_Example_Handler_Test : Test_Command_Base
    {
        [Fact]
        public async Task Creat_Example_Handler__OK()
        {
            var handler = new Creat_Exemple.Handler(DbContext);
            Guid id_client = Guid.Parse("f0c36cfb-58e2-4777-b6db-f6cdde1efa9c");

            var name = "Dan_Creat";
            var email = "wegwfrw@mail.ru";
            var OrderId = await handler.Handle(
                new Creat_Exemple.Command
                {    
                    Name = name,
                    Email = email,
                    
                },
                  CancellationToken.None);
            Assert.NotNull(
                await DbContext.Domain_Examples.SingleOrDefaultAsync(order =>
                order.Id == OrderId && order.Name == name && order.Email == email));
        }
    }
}
