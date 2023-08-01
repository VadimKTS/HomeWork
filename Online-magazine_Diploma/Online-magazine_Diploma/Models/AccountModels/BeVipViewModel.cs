using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.Models.AccountModels
{
    public class BeVipViewModel
	{
        [Required(ErrorMessage = "Введите Email")]
		//[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

		[Required(ErrorMessage = "Введите номер карты")]
        [DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

        [Required(ErrorMessage = "Введите дату окончания срока действия карты")]
        //[DataType(DataType.Date)]
        [RegularExpression(@"[0-9]{2}/[0-9]{2}")]
        public string Expires { get; set; }

        [Required(ErrorMessage = "Введите CVV. (На обратной стороне карты)")]
		[RegularExpression(@"[0-9]{3}")]
        public string CvvCode { get; set; }

        [Required(ErrorMessage = "Введите ИМЯ держателя карты.")]
		[RegularExpression(@"[A-Za-z]{1,20}" + @" " + @"[A-Za-z]{1,20}")]
		public string CardHolderName { get; set; }
	}
}
