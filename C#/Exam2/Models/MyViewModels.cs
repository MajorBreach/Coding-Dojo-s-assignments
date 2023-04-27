#pragma warning disable CS8618
namespace Exam2.Models;

public class MyViewModel
{
    public User? User { get; set; }
    public List<User> AllUsers { get; set; }

    public Wedding? Wedding { get; set; }
    public List<Wedding> AllWeddings { get; set; }

    public Guest? Guest { get; set; }
    public List<Guest> AllGuests { get; set; }


}