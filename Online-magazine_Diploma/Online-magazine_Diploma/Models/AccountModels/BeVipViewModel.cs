using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.Models.AccountModels
{
    public class BeVipViewModel
	{
        [Required]
        //[RegularExpression(@"[A-Za-z0-9._%+-]" + @"[@]" + @"[A-Za-z0-9.-]" + @"[A-Za-z]{2,4}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

		//[Required(ErrorMessage = "Введите пароль")]
		//[DataType(DataType.Password)]
		//public string PasswordHash { get; set; }//дописать донатилку!!!!!!!!!!!!!!!(@"[0-9]{2}+/.[0-9]{2}")

		[Required]
        [DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly Expires { get; set; }

        [Required]
		[RegularExpression(@"[0-9]{3}")]
        public string CvvCode { get; set; }

        [Required]
		[RegularExpression(@"[A-Za-z]{1,20}" + @" " + @"[A-Za-z]{1,20}")]
		public string CardHolderName { get; set; }
	}
}
