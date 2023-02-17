using AutoMapper;
using DepartamentosMunicipiosAPI.DTOs;
using DepartamentosMunicipiosAPI.Entities;
using System.Diagnostics;

namespace DepartamentosMunicipiosAPI.Mappers
{
    public class DepartamentoMapper
    {

        private readonly IMapper _mapper;
        public DepartamentoMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public DepartamentoDTO getDTO(Departamento entity)
        {
            return _mapper.Map<DepartamentoDTO>(entity);
        }

        public List<DepartamentoDTO> getListDTO(List<Departamento> entities)
        {
            return _mapper.Map<List<DepartamentoDTO>>(entities);
        }

        public Departamento getEntity(DepartamentoDTO dto)
        {
            return _mapper.Map<Departamento>(dto);
        }
    }
}
