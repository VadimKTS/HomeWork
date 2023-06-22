using Online_magazine_Diploma.DataAccess.Entity;
using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.Models.ArticleModels
{
	public class ManageArticlesViewModel 
    {
        [MaxLength(85)]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(85)]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public Guid? AuthorUserId { get; set; }

        public User AuthorUser { get; set; }

        public Guid? ArticleTypeId { get; set; }
        public ArticleType ArticleType { get; set; }
		public string AdminDescriptionForEdit { get; set; }
		public bool IsEditNeeded { get; set; }
		public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }
		public bool IsApprovedForPublication { get; set; }
	}
}
