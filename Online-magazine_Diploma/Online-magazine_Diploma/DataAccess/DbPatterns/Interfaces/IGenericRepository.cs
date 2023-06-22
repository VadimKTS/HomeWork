namespace Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> Create(T t);
        Task Update(T t);
        Task Delete(T t);
        Task<T> Get(Guid id);
        Task<IList<T>> GetAll();   // или IEnumerable
    }
}
