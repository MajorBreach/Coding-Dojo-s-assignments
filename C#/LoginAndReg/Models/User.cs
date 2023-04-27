#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAndReg.Models;


public class User
{
    [Key]
    public int UserId { get; set; }
    [Required(ErrorMessage ="Do you not have a First name?")]
    public string FirstName { get; set; } 

    [Required(ErrorMessage ="Do you not have a Last name?")]
    public string LastName { get; set; } 

    [Required(ErrorMessage ="Do you not have a Password?")]
    [DataType(DataType.Password)]
    public string Password { get; set; } 

    [Required(ErrorMessage ="Password Mismatch!")]
    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    [Display(Name ="ConfirmPassword")]
    public string ConfirmPassword { get; set; } 

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}