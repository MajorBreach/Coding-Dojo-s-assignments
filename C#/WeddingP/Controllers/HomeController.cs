using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingP.Models;
//Anthony was a huge help!


namespace WeddingP.Controllers;

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
        return View("Index");
    }

    // User Routes
    [HttpPost("/login")]
    public IActionResult Login(Login userlog)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userlog.UserEmail);
            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "invaild Email/Password");
                return Index();
            }
            PasswordHasher<Login> hasher = new PasswordHasher<Login>();
            var result = hasher.VerifyHashedPassword(userlog, userInDb.Password, userlog.UserPassword);
            if (result == 0)
            {
                ModelState.AddModelError("Email", "invaild Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return Allweddings();
        }
        return View("Index");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("FirstName", newUser.FirstName);
            return Allweddings();
        }
        else
        {
            return View("Index");
        }
    }



    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }

        // Wedding Routes

    [HttpGet("/weddings")]
    public IActionResult Allweddings()
    {
        ViewBag.EveryWedding = _context.Weddings.Include(w=>w.Guests).ToList();
        return View("Dashboard");
    }

    [HttpGet("/weddings/{WeddingId}")]
    public IActionResult OneWedding(int WeddingId)
    {
        USEVIEW OneWedding = new USEVIEW
        {
            Wedding = _context.Weddings.FirstOrDefault(a => a.WeddingId == WeddingId),
            EveryGuest = _context.Guests
            .Include(u => u.User)
            .Include(w => w.Wedding)
            .Where(w => w.WeddingId == WeddingId).ToList()
        };
        return View("ShowOne",OneWedding);
    }

    [HttpGet("/weddings/new")]
    public IActionResult form()
    {
        return View("NewWedding");
    }

    [HttpPost("/weddings/newPost")]
    public IActionResult createWedding(Wedding newWedding)
    {
        newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
        if (ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();
            int createweddingID = newWedding.WeddingId;
            return RedirectToAction("OneWedding", new {WeddingId = createweddingID});
        }
        else
        {
            return form();
        }
    }

    [HttpPost("/wedding/{WeddingId}/update")]
    public IActionResult AddGuest(Guest addGuest, int WeddingId)
    {
        addGuest.WeddingId = WeddingId;
        addGuest.UserId = (int)HttpContext.Session.GetInt32("UserId");
        if(ModelState.IsValid)
        {
            _context.Add(addGuest);
            _context.SaveChanges();
            return RedirectToAction("AllWeddings");
        }
        else
        {
            return RedirectToAction("NewWedding");
        }
    }
    
    [HttpPost("/wedding/{WeddingId}/Guest/Delete")]
    public IActionResult CantMakeit(int WeddingId)
    {
        Guest? RemoveGuest =_context.Guests.FirstOrDefault(g => g.WeddingId == WeddingId && g.UserId == (int)HttpContext.Session.GetInt32("UserId"));
        _context.Guests.Remove(RemoveGuest);
        _context.SaveChanges();
        return RedirectToAction("AllWeddings");
    }

    [HttpPost("/wedding/{WeddingId}/Delete")]
    public IActionResult WeddingDelete(int WeddingId)
    {
        Wedding? DeleteWedding = _context.Weddings.SingleOrDefault(w => w.WeddingId == WeddingId);
        _context.Weddings.Remove(DeleteWedding);
        _context.SaveChanges();
        return RedirectToAction("AllWeddings");
    }
    


























        //Stop Here, End routes====================
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
