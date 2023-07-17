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

		public async Task<Comment> CreateCommentAsync(Comment comment)
		{
			return await UnitOfWork.Comments.CreateAsync(comment);
		}

		public async Task<Comment> GetCommentByIdAsync(Guid id)
		{
			IList<Comment> comments = await UnitOfWork.Comments.GetAllAsync();
			return comments.FirstOrDefault(x => x.Id == id);
		}
		public async Task<IList<Comment>> GetCommentsByArticleIdAsync(Guid id)
		{
			IList<Comment> comments = await UnitOfWork.Comments.GetAllAsync();
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
		public async Task<IList<Comment>> GetCommentsByUserIdAsync(Guid id)
		{
			IList<Comment> comments = await UnitOfWork.Comments.GetAllAsync(); 
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

		public async Task<IList<Comment>> GetAllCommentsAsync()
		{
			IList<Comment> comments = await UnitOfWork.Comments.GetAllAsync();
			return comments;
		}

		public async Task UpdateCommentAsync(Comment comment)
		{
			await UnitOfWork.Comments.UpdateAsync(comment);
		}
	}
}
