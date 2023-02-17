using DepartamentosMunicipiosAPI.Entities;

namespace DepartamentosMunicipiosAPI.Repositories
{
    public interface IMunicipioRepository
    {
        Task<List<Municipio>> GetAllAsync();
        Task<Municipio> GetById(int id);
        Task<int> Insert(Municipio entity);
        Task<int> Update(Municipio entity);
        Task<int> Delete(int id);
        Task<List<Municipio>> GetPagedList(int skip, int take);
        Task<int> Count();
    }
}
