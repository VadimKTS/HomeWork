using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.DataAccess.Entity
{
    public class User
    {
        [MaxLength(85)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(85)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(85)]
        public string PasswordHash { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public UserRole UserRole { get; set; }
        public DateTime VipStatusEnd { get; set; }
		public bool IsDeleted { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
		public virtual ICollection<Article> Article { get; set; }
    }
}
