using DepartamentosMunicipiosAPI.DatabaseContexts;
using DepartamentosMunicipiosAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepartamentosMunicipiosAPI.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Departamento> _dbSet;
        public DepartamentoRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<Departamento>();
        }

        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
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

        public async Task<List<Departamento>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Departamento> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Departamento>> GetPagedList(int skip, int take)
        {
            return await _dbSet.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<int> Insert(Departamento entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Departamento entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
