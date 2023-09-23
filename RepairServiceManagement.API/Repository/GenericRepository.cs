using Microsoft.EntityFrameworkCore;
using RepairServiceManagement.API.Data;
using RepairServiceManagement.API.IRepository;

namespace RepairServiceManagement.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RepairServiceDbContext _context;

        public GenericRepository(RepairServiceDbContext context)
        {
            this._context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            //.Set<T>() means access to the DbSet<T> 
            var results = await _context.Set<T>().ToListAsync();
            return results;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);

            return entity != null;
        }

    }
}
