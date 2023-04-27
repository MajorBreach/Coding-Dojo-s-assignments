using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Exam2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Exam2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // ? ======Register/Login Page======
    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("/users/create")]
        public IActionResult CreateUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);

                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                HttpContext.Session.SetString("UserName", newUser.FirstName);
                return RedirectToAction("ViewAll");
            } 
            else
            {
                return View("Index");
            }
        }

    [HttpPost("/users/login")]
    public IActionResult LoginUser(LoginUser userSubmission)
    {
        if(ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
            if(userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);

            if(result == 0)
            {
                ModelState.AddModelError("LPassword", "Invalid Email/Password");
                return View("Index");
            } else{
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                HttpContext.Session.SetString("UserName", userInDb.FirstName);
                return RedirectToAction("ViewAll");
            }
        } else {
            return View("Index");
        }
    }




// ? ====== Dashboard/Page being redirected to after Register or Login ======


    [HttpGet("/Dashboard")]
    public IActionResult ViewAll()
    {
        return View("Dashboard");
    }

//============= CRUD=================



    [HttpGet("Dishes/New")]
    public IActionResult RenderCreate()
    {
        return View("Create");
    }

    [HttpPost("Dishes/Create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            // call the method to render the create page
            return RenderCreate();
        }
    }

    [HttpGet("Dishes/{id}")]
    public IActionResult ReadOne(int id)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        return View("Read", OneDish);
    }
// ----------------Render Edit Page-------------------
    [HttpGet("Dishes/{id}/edit")]
    public IActionResult Edit(int id)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(i => i.DishId == id);
        return View("Edit", DishToEdit);
    }

    [HttpPost("Dishes/{id}/update")]
    public IActionResult Update(Dish newDish, int id)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(i => i.DishId == id);
        if (ModelState.IsValid)
        {
            OldDish.Name = newDish.Name;
            OldDish.Chef = newDish.Chef;
            OldDish.Tastiness = newDish.Tastiness;
            OldDish.Calories = newDish.Calories;
            OldDish.Description = newDish.Description;
            OldDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Edit", OldDish);
        }
    }

    [HttpPost("Dishes/{id}/Destroy")]
    public IActionResult Delete(int id)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishId == id);
        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }





// ====Actions/Small Things====

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }




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
