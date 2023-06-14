using Application.Common.Mapping;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.List_Domain_Example
{
    public partial class List_Domain_Example
    {
       public class List_Model: IMap_With<Domain_Example>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            public void Mapping (Profile profile)
            {
                profile.CreateMap<Domain_Example, List_Model>();             
            }

        }
    }
}
