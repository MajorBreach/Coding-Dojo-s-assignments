#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojosurveyWVals.Models;

public class Survey 
{
    [Required]
    [MinLength(2)]
    public string Name {get;set;}
    [Required]
    public string Location {get;set;}
    [Required]
    public string Lang {get;set;}
    [MinLength(30)]
    public string Comment {get;set;}
    
}