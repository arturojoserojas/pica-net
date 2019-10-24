using System;
using System.ComponentModel.DataAnnotations;

namespace webapp.Models
{
    public class LoginModel
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }

}
}
