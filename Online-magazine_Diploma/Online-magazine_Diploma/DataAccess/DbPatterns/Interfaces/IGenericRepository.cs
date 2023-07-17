namespace Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> CreateAsync(T t);
        Task UpdateAsync(T t);
        Task<T> GetAsync(Guid id);
        Task<IList<T>> GetAllAsync();   // или IEnumerable
    }
}
