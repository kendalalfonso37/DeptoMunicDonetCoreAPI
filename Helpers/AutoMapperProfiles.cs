using AutoMapper;
using DepartamentosMunicipiosAPI.DTOs;
using DepartamentosMunicipiosAPI.Entities;

namespace DepartamentosMunicipiosAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            CreateMap<DepartamentoCreationDTO, Departamento>();

        }
    }
}
