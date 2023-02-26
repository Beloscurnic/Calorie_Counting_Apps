using Application.Common.Mapping;
using Application.Interfaces;
using AutoMapper;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Common
{
    public class Query_Test_Mapper : IDisposable
    {
        public Apps_DbContext dbcontext;
        public IMapper mapper;
        public Query_Test_Mapper()
        {
            dbcontext = CRM_Context_Factory.Create();
            var configuration = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile(new AssemblyMappingProfile(typeof(I_DbContext).Assembly));
            });
            mapper = configuration.CreateMapper();
        }
        public void Dispose()
        {
            CRM_Context_Factory.Destroy(dbcontext);
        }
        [CollectionDefinition("QueryRequests")]
        public class QueryRequests : ICollectionFixture<Query_Test_Mapper>
        {

        }
    }
}
