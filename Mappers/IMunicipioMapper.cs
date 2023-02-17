using AutoMapper;
using DepartamentosMunicipiosAPI.DTOs;
using DepartamentosMunicipiosAPI.Entities;

namespace DepartamentosMunicipiosAPI.Mappers
{
    public interface IMunicipioMapper
    {
        public MunicipioDTO GetDTO(Municipio Entity);
        public List<MunicipioDTO> GetListDTO(List<Municipio> entities);
        public Municipio GetEntity(MunicipioCreationDTO dto);
    }
}
