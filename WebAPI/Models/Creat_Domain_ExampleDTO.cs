using Application.Common.Mapping;
using Application.Requests.Commands.Creat_Exemple;
using AutoMapper;

namespace WebAPI.Models
{
    public class Creat_Domain_ExampleDTO : IMap_With<Creat_Exemple.Command>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Creat_Domain_ExampleDTO, Creat_Exemple.Command>();
        }
    }
}
