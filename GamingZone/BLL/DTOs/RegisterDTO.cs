using BLL.Validations;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        [UniqueEmail]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        [UniqueUsername]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [PasswordMatch]
        public string ConfirmPassword { get; set; }

        public string ContactNumber { get; set; }
    }
}