using DepartamentosMunicipiosAPI.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace DepartamentosMunicipiosAPI.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepositoryAsync(ApplicationDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> Insert(T entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Delete(int id)
        {
            var exists = GetById(id);
            if (exists != null)
            {
                return 0;
            }
            _context.Remove(exists);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetPagedList(int skip, int take)
        {
            return await _dbSet.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }
    }
}
