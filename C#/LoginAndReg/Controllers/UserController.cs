using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndReg.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginAndReg.Controllers;

public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public UserController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("/User/new")]
    public IActionResult UserNew()
    {
        return View("UserNew");
    }

[HttpPost("/User/Create")]
    public IActionResult UserCreate(User newuser)
    {
        if(!ModelState.IsValid)
        {
            return View("~/Views/Home/index.cshtml");
        }

    PasswordHasher<User>hasher = new PasswordHasher<User>();


        _context.Users.Add(newuser);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("userid", newuser.UserId);

        return RedirectToAction("Dashboard" ,"Home");
    }

}