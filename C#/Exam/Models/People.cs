#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Exam.Models;

public class People
{


    [Key]
    public int PeopleId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("Coupon")]
    public int CouponId { get; set; }

    public Coupon? Coupon { get; set; }
    public User? User { get; set; }

}