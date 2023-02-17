using AutoMapper;
using DepartamentosMunicipiosAPI.DTOs;
using DepartamentosMunicipiosAPI.Entities;

namespace DepartamentosMunicipiosAPI.Mappers
{
    public class GenericMapper<TEntity, TEntityDTO>:IGenericMapper<TEntity, TEntityDTO> where TEntity: Entity where TEntityDTO : EntityDTO 
    {
        private readonly IMapper _mapper;
        public GenericMapper(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public EntityDTO getDTO(Entity entity)
        {
            return _mapper.Map<EntityDTO>(entity);
        }

        public List<EntityDTO> getListDTO(List<Entity> entities)
        {
            return _mapper.Map<List<EntityDTO>>(entities);
        }

        public Entity getEntity(EntityDTO dto)
        {
            return _mapper.Map<Entity>(dto);
        }

    }
}
