using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.DataAccess.Entity
{
    public class ArticleType
    {
		[MaxLength(85)]
		public Guid Id { get; set; }
                
        [Required]
        [MaxLength(85)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
		public bool IsDeleted { get; set; }
		public virtual ICollection<Article> Articles { get; set; }

    }
}
