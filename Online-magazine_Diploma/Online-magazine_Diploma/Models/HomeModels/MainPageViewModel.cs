using Online_magazine_Diploma.DataAccess.Entity;
using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.Models.HomeModels
{
	public class MainPageViewModel
	{
		public IList<ArticleType> ArticleTypes { get; set; }
	}
}
