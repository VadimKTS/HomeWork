using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.DataAccess.Entity
{
	public class Titel
	{
		public Guid Id { get; set; }
		[Required]
		[StringLength(80)]
		public string Name { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime ActivateDate { get; set; }
		public string ImageAddress { get; set; }
		public IList<Article> TopArticles { get; set; }
		//public virtual ICollection<Article> Articles { get; set; }
	}
}
