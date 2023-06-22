using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.DataAccess.Entity
{
    public class Comment
    {
        [Required]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }

    }
}
