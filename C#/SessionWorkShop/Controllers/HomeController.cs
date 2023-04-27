using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkShop.Models;

namespace SessionWorkShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("index");
    }
    [HttpPost("build")]
    public IActionResult build(string Name)
    {
        HttpContext.Session.SetString("Name", $"{Name}");
        HttpContext.Session.SetInt32("Num", 10);
        return RedirectToAction("Display");
    }

    [HttpGet("display")]
    public IActionResult Display()
    {
        return View("Display");
    }


    [HttpPost("Home/UpdateNum")]
    public IActionResult Math(string button)
    {
        int number = Convert.ToInt32(HttpContext.Session.GetInt32("Num"));
        if (button == "add")
        {
            int newNum = number + 1;
            HttpContext.Session.SetInt32("Num", newNum);
        }
        if (button == "subtract")
        {
            int newNum = number - 1;
            HttpContext.Session.SetInt32("Num", newNum);
        }
        if (button == "multiply")
        {
            int newNum = number * 2;
            HttpContext.Session.SetInt32("Num", newNum);
        }
        if (button == "random")
        {
            Random rando = new Random();
            int newNum = number + (rando.Next(-1, 100));
            HttpContext.Session.SetInt32("Num", newNum);
        }
        return RedirectToAction("Display");
    }


    [HttpPost("/Home/Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }















    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
