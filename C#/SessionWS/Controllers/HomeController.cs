using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWS.Models;

namespace SessionWS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("index");
    }
    [HttpPost("/user")]
    public IActionResult user(string username)
    {

        HttpContext.Session.SetString("Username", $"{username}");
        HttpContext.Session.SetInt32("Usernum", 22);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("dashboard/fun")]
    public IActionResult add(string add)
    {
        int usernum = Convert.ToInt32(HttpContext.Session.GetInt32("Usernum"));
        int nums = usernum + 1;
        HttpContext.Session.SetInt32("Usernum", nums);
        return RedirectToAction("Dashboard");
    }

    public IActionResult subtract(string subtract)
    {
        int usernum = Convert.ToInt32(HttpContext.Session.GetInt32("Usernum"));
        int nums = usernum - 1;
        HttpContext.Session.SetInt32("Usernum", nums);
        return RedirectToAction("Dashboard");
    }
    public IActionResult multi(string multi)
    {
        int usernum = Convert.ToInt32(HttpContext.Session.GetInt32("Usernum"));
        int nums = usernum * 2;
        HttpContext.Session.SetInt32("Usernum", nums);
        return RedirectToAction("Dashboard");
    }
    public IActionResult random(string rando)
    {
        int usernum = Convert.ToInt32(HttpContext.Session.GetInt32("Usernum"));
        Random random = new Random();
        int nums = usernum + (random.Next(0,100));
        HttpContext.Session.SetInt32("Usernum", nums);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("/dashboard/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("index");
    }


    [HttpGet("dashboard")]
    public IActionResult dashboard()
    {
        return View("Dashboard");
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
