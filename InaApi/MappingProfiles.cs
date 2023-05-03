using AutoMapper;
using Entities;
using InaApi.Models;

namespace InaApi
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //En el constructor vamos a definir todos los mapeos.

            CreateMap<TbCliente, ClienteDTO>().ForMember(d => d.Nombre, m => m.MapFrom(s => s.CedulaNavigation.Nombre))
                .ForMember(d => d.Apellido1, m => m.MapFrom(s => s.CedulaNavigation.Apellido1))
                .ForMember(d => d.Apellido2, m => m.MapFrom(s => s.CedulaNavigation.Apellido2))
                .ForMember(d => d.FechaNac, m => m.MapFrom(s => s.CedulaNavigation.FechaNac))
                .ForMember(d => d.Genero, m => m.MapFrom(s => s.CedulaNavigation.Genero))
                .ForMember(d => d.Cedula, m => m.MapFrom(s => s.CedulaNavigation.Cedula)).ReverseMap();
            /*CreateMap<ClienteDTO, TbCliente>();
            CreateMap<List<TbCliente>, List<ClienteDTO>>();
            CreateMap <List<ClienteDTO>, List<TbCliente>>();*/

        }
    }
}
