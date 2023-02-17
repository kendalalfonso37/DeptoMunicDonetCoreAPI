using DepartamentosMunicipiosAPI.DTOs;
using DepartamentosMunicipiosAPI.Entities;

namespace DepartamentosMunicipiosAPI.Mappers
{
    public interface IGenericMapper<TEntity, TEntityDTO> where TEntity : Entity where TEntityDTO : EntityDTO
    {
        EntityDTO getDTO(Entity entity);
        List<EntityDTO> getListDTO(List<Entity> entities);
        Entity getEntity(EntityDTO dto);
    }
}
