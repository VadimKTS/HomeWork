using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.Models.ArticleModels
{
	public class AddArticlesViewModel
    {
        [Required]
        [MaxLength(85)]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public Guid ArticleTypeId { get; set; }
    }
}
