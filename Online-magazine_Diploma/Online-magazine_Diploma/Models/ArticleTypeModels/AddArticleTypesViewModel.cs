using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.Models.ArticleTypeModels
{
	public class AddArticleTypesViewModel
    {
        [Required]
        [MaxLength(85)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
