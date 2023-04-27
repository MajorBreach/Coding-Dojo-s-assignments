#pragma warning disable CS8618
namespace Exam.Models;




public class UseView
{

    public List<Coupon> AllCoupons {get;set;}
    public List<User> EveryUser {get;set;}
    public List<People>? AllPeople {get;set;}

    public Coupon? Coupon{get;set;}
    public User? User{get;set;}
    public People? People {get;set;}
}