#pragma warning disable CS8618
namespace WeddingP.Models;




public class USEVIEW
{
    public List<Wedding> EveryWedding{get;set;}
    public List<User> EveryUser {get;set;}
    public List<Guest> EveryGuest{get;set;}

    public Wedding? Wedding{get;set;}
    public User? User{get;set;}
    public Guest? Guest {get;set;}
}