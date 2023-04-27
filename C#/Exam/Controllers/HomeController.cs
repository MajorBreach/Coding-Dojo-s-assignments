using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exam.Models;



namespace Exam.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Index +++++++++++++++++++++++++++
        [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }


    // User Login/Reg ++++++++++++++++++++++++++++
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
            HttpContext.Session.SetString("UserName", userInDb.UserName);
            return RedirectToAction("Dashboard");
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
            HttpContext.Session.SetString("UserName", newUser.UserName);
            return RedirectToAction("Dashboard");
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

//Main Routes+++++++++++++++++++++++++

    [HttpGet("/coupons")]
    public IActionResult Dashboard()
    
    {
        UseView Model = new UseView
        {
        AllCoupons = _context.Coupons.Include(c=>c.Peoples).Include(c => c.User).ToList(),
        User = _context.Users.SingleOrDefault(u =>u.UserId == HttpContext.Session.GetInt32("UserId"))
        };
        return View("Dashboard", Model);
            
    }

    [HttpPost("/coupons/newCoupon")]
    public IActionResult createCoupon(Coupon newCoupon)
    {
        newCoupon.UserId = (int)HttpContext.Session.GetInt32("UserId");
        if (ModelState.IsValid)
        {
            _context.Add(newCoupon);
            _context.SaveChanges();
            int createCouponID = newCoupon.CouponId;
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Create");
        }
    }


    
    [HttpGet("/coupon/new")]
    public IActionResult NewCoupon()
    {
        return View("Create");
    }


    [HttpPost("/coupon/new/UseCoupon")]
    public IActionResult UseCoupon(People addPerson, int CouponId)
    {
        addPerson.CouponId = CouponId;
        addPerson.UserId = (int)HttpContext.Session.GetInt32("UserId");
        if (ModelState.IsValid)
        {
            _context.Add(addPerson);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        else
        {
            return RedirectToAction("NewCoupon");
        }
    }


    [HttpGet("/user/{UserId}")]
    public IActionResult Viewone(int UserId)
    {
        UseView OneCoupon = new UseView
        {
            User = _context.Users
            .Include(u => u.UserCoupon)
            .Include(u => u.AllPeople)
            .ThenInclude(p => p.Coupon)
            .SingleOrDefault(u => u.UserId == UserId)
        };
        return View("ShowOne",OneCoupon);
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
