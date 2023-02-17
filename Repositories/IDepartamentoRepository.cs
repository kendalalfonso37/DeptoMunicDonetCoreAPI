using DepartamentosMunicipiosAPI.Entities;

namespace DepartamentosMunicipiosAPI.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<List<Departamento>> GetAllAsync();
        Task<Departamento> GetById(int id);
        Task<int> Insert(Departamento entity);
        Task<int> Update(Departamento entity);
        Task<int> Delete(int id);
        Task<List<Departamento>> GetPagedList(int skip, int take);
        Task<int> Count();

    }
}
