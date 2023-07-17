using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.Services.Interfaces
{
	public interface ICommentService
	{
		Task<Comment> GetCommentByIdAsync(Guid id);
		Task<IList<Comment>> GetCommentsByArticleIdAsync(Guid id);
		Task<IList<Comment>> GetCommentsByUserIdAsync(Guid id);
		Task<IList<Comment>> GetAllCommentsAsync();
		Task<Comment> CreateCommentAsync(Comment comment);
		Task UpdateCommentAsync(Comment comment);
	}
}
