using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.IdentityViewModels
{
    public class CreateUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public int DefaultLanguageId { get; set; }
        public int? CountryId { get; set; }

    }
}
