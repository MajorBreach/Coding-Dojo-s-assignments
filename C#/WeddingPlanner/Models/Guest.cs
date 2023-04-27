#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;
public class Guest
{
    [Key]
    public int GuestId { get; set; }
    
    [ForeignKey("User")]
    public int UserId { get; set; } 
    public User User { get; set; }

    [ForeignKey("Wedding")]
    public int WeddingId { get; set; }
    public Wedding Wedding { get; set; } 

}
