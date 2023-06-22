using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Article> Articles { get; }
        IGenericRepository<ArticleType> ArticleTypes { get; }
        IGenericRepository<Comment> Comments { get; }
        IGenericRepository<Rating> Ratings { get; }
        IGenericRepository<Titel> Titels { get; }
    }
}
