#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CNDs.Models;
public class Chef
{
    [Key]
    public int ChefId { get; set; }
    [Required]
    public string Name { get; set; } 
    [Required]
    [DateOfBirth(MinAge = 1, MaxAge = 90)]
    public DateTime DateOfBirth { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish>?Dishes {get; set;} = new List<Dish>();

}
// Asked for help
public class DateOfBirthAttribute : ValidationAttribute
{
    public int MinAge { get; set; }
    public int MaxAge { get; set; }

    public override bool IsValid(object value)
    {
        if (value == null)
            return true;

        var val = (DateTime)value;

        if (val.AddYears(MinAge) > DateTime.Now)
            return false;

        return (val.AddYears(MaxAge) > DateTime.Now);
    }

}