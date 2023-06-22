using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.Models.ArticleModels
{
	public class ArticlesViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(85)]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public string ArticleTypeName { get; set; }
		public string AdminDescriptionForEdit { get; set; }
		public bool IsEditNeeded { get; set; }
		public bool IsApprovedForPublication { get; set; }
        public bool IsEdited { get; set; }
	}
}
