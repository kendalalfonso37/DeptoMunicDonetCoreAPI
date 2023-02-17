using AutoMapper;
using DepartamentosMunicipiosAPI.DTOs;
using DepartamentosMunicipiosAPI.Entities;

namespace DepartamentosMunicipiosAPI.Mappers
{
    public class MunicipioMapper : IMunicipioMapper
    {
        private readonly IMapper _mapper;

        public MunicipioMapper(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public MunicipioDTO GetDTO(Municipio Entity)
        {
            return _mapper.Map<MunicipioDTO>(Entity);
        }

        public Municipio GetEntity(MunicipioCreationDTO dto)
        {
            return _mapper.Map<Municipio>(dto);
        }

        public List<MunicipioDTO> GetListDTO(List<Municipio> entities)
        {
            return _mapper.Map<List<MunicipioDTO>>(entities);
        }
    }
}
