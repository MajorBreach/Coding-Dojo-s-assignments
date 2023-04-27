#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CNDs.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string DishName { get; set; }
    [Required]
    [Range(1,5)]
    public int calories { get; set; }
    [Required]
    [Range(0, 5000)]
    public int Tastiness { get; set; }
    public int ChefId {get; set;}
    public Chef ? Chef {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [NotMapped]
    public List<Chef>Chefs { get; set; } = new List<Chef>();
}
                
