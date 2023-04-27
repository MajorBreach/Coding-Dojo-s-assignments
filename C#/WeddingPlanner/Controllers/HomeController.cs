using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

[HttpGet("/")]
public IActionResult Index()
{
    return View("login");
}

    [HttpGet("/login")]
    public IActionResult login()
    {
        return View("login");
    }

    [HttpPost("")]
    public IActionResult register(User model)
    {
        if (ModelState.IsValid)
        {
            User ValidUser = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password
            };

            _context.Add(ValidUser);
            _context.SaveChanges();
            HttpContext.Session.SetString("Name", ValidUser.FirstName);
            HttpContext.Session.SetInt32("UserId", ValidUser.UserId);
            return View("Dashboard");
        }
        return View("register");
    }
    [HttpGet("/register")]
    public IActionResult RegForm()
    {
        return View("register");
    }

    [HttpPost("/login")]
    public IActionResult login(User model)
    {
        if (ModelState.IsValid)
        {
            User? existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (existingUser.Password == model.Password)
            System.Console.WriteLine(existingUser);
                {
                HttpContext.Session.SetInt32("UserId", existingUser.UserId);
                return RedirectToAction("dash");
                }
        }
        return View("login");
    }


    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("login");
    }


[HttpGet("/dashboard")]
public IActionResult dash()
{
    {
        Wedding Allweddings = _context..Include(w => w.Wedding).ThenInclude(u =>u.UserId).ToList();
        return View("Dashboard",Allweddings);
    }
}




[HttpGet("/details/{weddingId}")]
public IActionResult Details(int weddingId)
{
    var weddingselected = _context.Weddings.Include(w =>w.Guests).ThenInclude(g =>g.User).FirstOrDefault(u => u.WeddingId == weddingId);
    return View("Details", weddingselected);
}

[HttpGet("/weddings")]
public IActionResult AddWeddings()
{
    return View("AddWedding");
}

[HttpPost("/weddings")]
public IActionResult AddWeddings(Wedding newWedding)
{
    newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
    _context.Weddings.Add(newWedding);
    _context.SaveChanges();
    return RedirectToAction("Details", newWedding.WeddingId);
}

[HttpGet("/weddings/delete/{WeddingId}")]
public IActionResult DeleteWedding(int WeddingId)
{
    Wedding? wedding = _context.Weddings.FirstOrDefault(w => w.WeddingId == WeddingId);
    _context.Weddings.Remove(wedding);
    _context.SaveChanges();
    return RedirectToAction("Dashboard");
}

[HttpGet, Route("/weddings/RSVP/{weddingId}")]
public IActionResult RSVP(Guest guest, int WeddingId)
{
    guest.WeddingId = WeddingId;
    guest.UserId = (int)HttpContext.Session.GetInt32("UserId");
    if(guest != null)
    {
        RedirectToAction("login");
    }
    else{
    _context.Add(guest);
    _context.SaveChanges();
    }
    return RedirectToAction("Dashboard");

}














    //0ther Routes
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
