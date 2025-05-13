using System.ComponentModel.DataAnnotations;

public class RegisteredUser
{
    [Key]
    public int UserId { get; set; }
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(100, ErrorMessage = "First Name cannot be longer than 100 characters.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(100, ErrorMessage = "Last Name cannot be longer than 100 characters.")]
    public string Lastname { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "Password must be at least 6 characters long.", MinimumLength = 6)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
    public string ProfilePicturePath { get; set; }
}
