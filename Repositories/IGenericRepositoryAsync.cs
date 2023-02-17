namespace DepartamentosMunicipiosAPI.Repositories
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
        Task<List<T>> GetPagedList(int skip, int take);
        Task<int> Count();

    }
}
