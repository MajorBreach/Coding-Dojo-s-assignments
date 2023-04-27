#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace PandC.Models;
public class P
{
    public List<Join> joins { get; set; } = new List<Join>();
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string Name { get; set; } 
    [Required]
    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}