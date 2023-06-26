using Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.Services.Interfaces;
using System.Xml.Linq;

namespace Online_magazine_Diploma.Services.Service
{
	public class CommentService : ServiceConstructor, ICommentService
	{
		public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork) 
		{

		}

		public async Task<Comment> CreateComment(Comment comment)
		{
			return await UnitOfWork.Comments.Create(comment);
		}

		public async Task<Comment> GetCommentById(Guid id)
		{
			IList<Comment> comments = await UnitOfWork.Comments.GetAll();
			return comments.FirstOrDefault(x => x.Id == id);
		}
		public async Task<IList<Comment>> GetCommentsByArticleId(Guid id)
		{
			IList<Comment> comments = await UnitOfWork.Comments.GetAll();
			IList<Comment> articleComments = new List<Comment>();
			foreach (Comment comment in comments)
			{
				if (comment.ArticleId.Equals(id))
				{ 
					articleComments.Add(comment); 
				}
			}
			return articleComments;
			
		}
		public async Task<IList<Comment>> GetCommentsByUserId(Guid id)
		{
			IList<Comment> comments = await UnitOfWork.Comments.GetAll(); 
			IList<Comment> userComments = new List<Comment>();
			foreach (Comment comment in comments)
			{
				if (comment.UserId.Equals(id))
				{ 
					userComments.Add(comment); 
				}
			}
			return userComments;
		}

		public async Task<IList<Comment>> GetAllComments()
		{
			IList<Comment> comments = await UnitOfWork.Comments.GetAll();
			return comments;
		}

		public async Task UpdateComment(Comment comment)
		{
			await UnitOfWork.Comments.Update(comment);
		}

		public async Task DeleteComment(Comment comment)
		{
			await UnitOfWork.Comments.Delete(comment);
		}
	}
}
