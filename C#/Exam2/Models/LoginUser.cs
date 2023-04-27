#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Exam2.Models;

public class LoginUser
{
    [Required]
    public string Email {get;set;}

    [Required]
    public string Password {get;set;}
}