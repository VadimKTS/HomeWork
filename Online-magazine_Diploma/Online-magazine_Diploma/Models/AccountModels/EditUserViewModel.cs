using System.ComponentModel.DataAnnotations;

namespace Online_magazine_Diploma.Models.AccountModels
{
    public class EditUserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

    }
}
