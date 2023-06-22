using Microsoft.AspNetCore.Mvc.Rendering;
using Online_magazine_Diploma.DataAccess.Entity;
using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.Models.AdministratorModels
{
	public class ManageUsersViewModel
	{
		[Required]
		public Guid Id { get; set;}
		[Required]
		public string Name { get; set; }
		[Required]
		//[EmailAddress]
		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
		public string Email { get; set; }
		public UserRole UserRole { get; set; }
		static List<UserRole> roles { get; } = new()
		{
			UserRole.Administrator,
			UserRole.Author,
			UserRole.User,
			UserRole.VipUser,
		};
		public SelectList UserRoles { get; } = new SelectList(roles);

		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Rating> Ratings { get; set; }
		public virtual ICollection<Article> Articles { get; set; }
		public bool IsDeleted { get; set; }
	}
}
