
using DepartamentosMunicipiosAPI.DTOs;
using DepartamentosMunicipiosAPI.Entities;

namespace DepartamentosMunicipiosAPI.Mappers
{
    public interface IDepartamentoMapper
    {
        DepartamentoDTO getDTO(Departamento entity);
        List<DepartamentoDTO> getListDTO(List<Departamento> entities);
        Departamento getEntity(DepartamentoCreationDTO dto);
    }
}
