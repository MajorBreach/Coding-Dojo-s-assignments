#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace PandC.Models;
public class C
{
    public List<Join> Joins { get; set; } = new List<Join>();
    [Key]
    public int CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}