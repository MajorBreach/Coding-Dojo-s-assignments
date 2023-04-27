#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingP.Models;


public class Login
{
    [Required(ErrorMessage ="is required")]
    [EmailAddress]
    [Display(Name ="Email")]
    public string UserEmail {get;set;} = null!;

    
    [Required(ErrorMessage ="is required")]
    [MinLength(8,ErrorMessage ="is required")]
    [DataType(DataType.Password)]
    [Display(Name ="Password")]
    public string UserPassword {get;set;} = null!;
}