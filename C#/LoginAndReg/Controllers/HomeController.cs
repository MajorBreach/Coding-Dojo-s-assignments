using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndReg.Models;

namespace LoginAndReg.Controllers;

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
    if (HttpContext.Session.GetInt32("userid") != null)
    {
        return RedirectToAction("index");
    }
    return View("Dashboard");
    }

    [HttpGet("/dashboard")]
        public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("userid") == null)
        {
            return RedirectToAction("index");
        }
        return View("Dashboard");
    }

    [HttpGet("/user/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("index");
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
