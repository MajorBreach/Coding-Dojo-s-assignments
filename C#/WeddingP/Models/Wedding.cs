#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingP.Models;

public class Wedding
{


    [Key]
    public int WeddingId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [Required]
    public string NameOne { get; set; }

    [Required]
    public string NameTwo { get; set; }

    [Required]
    public string WeddingAddress { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public User? User { get; set; }

    public List<Guest> Guests { get; set; } = new List<Guest>();

}