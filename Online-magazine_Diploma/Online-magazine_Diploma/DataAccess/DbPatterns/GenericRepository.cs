using Microsoft.EntityFrameworkCore;
using Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces;

namespace Online_magazine_Diploma.DataAccess.DbPatterns
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyDbContext _dbContext;
        public GenericRepository(MyDbContext context) 
        {
            _dbContext = context;
        }

        public async Task<T> Create(T t)
        {
            _dbContext.Set<T>().Add(t);
            await _dbContext.SaveChangesAsync();
            return t;
        }

        public async Task Update(T t)
        {
            _dbContext.Set<T>().Update(t);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T t)
        {
            _dbContext.Set<T>().Remove(t);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
