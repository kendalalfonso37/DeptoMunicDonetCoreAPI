using DepartamentosMunicipiosAPI.DatabaseContexts;
using DepartamentosMunicipiosAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepartamentosMunicipiosAPI.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Municipio> _dbSet;

        public MunicipioRepository(ApplicationDbContext context) 
        {
            this._context = context;
            this._dbSet = context.Set<Municipio>();
        }
        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<int> Delete(int id)
        {
            var exists = await GetById(id);
            if (exists == null)
            {
                return 0;
            }
            _context.Remove(exists);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Municipio>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Municipio> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Municipio>> GetPagedList(int skip, int take)
        {
            return await _dbSet.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<int> Insert(Municipio entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Municipio entity)
        {
            var exists = await GetById(entity.Id);
            if (exists == null)
            {
                return 0;
            }
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
