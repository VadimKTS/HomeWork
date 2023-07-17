using Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces;
using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.DataAccess.DbPatterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _dbContext;

        public UnitOfWork(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<User> Users => new GenericRepository<User>(_dbContext);
        public IGenericRepository<Article> Articles => new GenericRepository<Article>(_dbContext);
        public IGenericRepository<ArticleType> ArticleTypes => new GenericRepository<ArticleType>(_dbContext);
        public IGenericRepository<Comment> Comments => new GenericRepository<Comment>(_dbContext);
        public IGenericRepository<Titel> Titels => new GenericRepository<Titel>(_dbContext);
    }
}
