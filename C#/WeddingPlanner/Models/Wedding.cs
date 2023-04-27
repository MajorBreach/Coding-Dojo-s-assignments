#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;
public class Wedding
{
    public List<Guest>Guests = new List<Guest>();
    public List<Wedding>AllWeddings = new List<Wedding>();

    [Key]
    public int WeddingId { get; set; }
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    [Required]
    public string WeddingOne { get; set; }

    [Required] 
    public string WeddingTwo { get; set; }

    [Required]
    public string  WeddingAddress { get; set; }

    [Required]
    public DateTime WeddingDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public Wedding Weddings { get; set; } 


}
