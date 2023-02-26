using Application.Requests.Commands.Creat_Exemple;
using Application.Requests.Queries.List_Domain_Example;
using AutoMapper;
using Persistence;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Common;
using Xunit;

namespace Test.Requests.Queries
{
    [Collection("QueryRequests")]
   public class Example_Domain_List_Handler
    {
        public Apps_DbContext Dbcontext;
        public IMapper Mapper;

        public Example_Domain_List_Handler(Query_Test_Mapper test_Mapper)
        {
            Dbcontext = test_Mapper.dbcontext;
            Mapper = test_Mapper.mapper;
        }

        [Fact]
        public async Task Get_List_Domain_Handler_Ok()
        {
            var hendler = new List_Domain_Example.Handler(Dbcontext, Mapper);

            var result = await hendler.Handle(
               new List_Domain_Example.Query
               {
                  
               }, CancellationToken.None);
            result.ShouldBeOfType<List_Domain_Example.List_View_Model>();
            result.List_Models.Count.ShouldBe(2);
        }
    }
}