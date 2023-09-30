using AutoMapper;
using Pro401.DTO.VehiculoDTO;
using Pro401.Entities;

namespace Pro401.Helpers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<VehiculoCreateDTO, Vehiculo>();
        }
    }
}
