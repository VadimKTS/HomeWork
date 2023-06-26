using Online_magazine_Diploma.DataAccess.Entity;

namespace Online_magazine_Diploma.Services.Interfaces
{
	public interface ICommentService
	{
		Task<Comment> GetCommentById(Guid id);
		Task<IList<Comment>> GetCommentsByArticleId(Guid id);
		Task<IList<Comment>> GetCommentsByUserId(Guid id);
		Task<IList<Comment>> GetAllComments();
		Task<Comment> CreateComment(Comment comment);
		Task UpdateComment(Comment comment);
		Task DeleteComment(Comment comment);
	}
}
