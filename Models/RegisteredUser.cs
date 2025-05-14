using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_and_Tourism.Models
{
    public class RegisteredUser
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        // Password fields are excluded from DB binding during edit
        //[NotMapped]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        //[NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }

        public string? ProfilePicturePath { get; set; }

        [NotMapped]
        public IFormFile? ProfilePicture { get; set; }
    }
}
