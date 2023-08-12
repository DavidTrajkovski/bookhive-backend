using System.ComponentModel.DataAnnotations;

namespace BookHiveDB.Domain.Dtos.Mvc
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Second name is required")]
        [StringLength(100)]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}