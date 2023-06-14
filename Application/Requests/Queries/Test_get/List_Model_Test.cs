using Application.Common.Mapping;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Test_get
{
    public partial class Test_get
    {
       public class List_Model_Test: IMap_With<Domain_Example>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            public static implicit operator List_Model_Test(Domain_Example domain_Example)
            {
                int Id = domain_Example.Id;
                string Name = domain_Example.Name;
                string Email = domain_Example.Email;

                return new List_Model_Test
                {
                    Id = domain_Example.Id,
                    Name = domain_Example.Name,
                    Email = domain_Example.Email
                };
            }
        }
    }
}
