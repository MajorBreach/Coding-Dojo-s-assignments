#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Exam.Models;

public class Coupon
{


    [Key]
    public int CouponId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [Required]
    public string CouponCode { get; set; }

    [Required]
    public string Website { get; set; }

    [Required]
    public string Description { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public User? User { get; set; }
    public List<People> Peoples { get; set; } = new List<People>();

}