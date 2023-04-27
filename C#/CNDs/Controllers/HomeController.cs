using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CNDs.Models;
using Microsoft.EntityFrameworkCore;
// Had help from Anthony and jacob / peyton
namespace CNDs.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

[HttpGet("")]
    public IActionResult Index()
    {
        List<Chef>Chefs = _context.Chefs.OrderByDescending(c => c.Name).Include(a => a.Dishes).ToList();
        return View("Index", Chefs);
    }

[HttpGet("/dishes")]
public IActionResult getDishes()
{
    List<Dish>Dishes = _context.Dishes.Include(c => c.Chef).ToList();
    return View("ViewDish", Dishes);
}

[HttpGet("/new/chef")]
public IActionResult NewChef()
{
    return View("NewChef");
}


[HttpGet("/new/dish")]
public IActionResult NewDish()
{
    ViewBag.Allchefs = _context.Chefs.ToList();
    return View("NewDish");
}

[HttpPost("/new/chef/create")]
public IActionResult createChef(Chef newChef)
{
    // if(ModelState.IsValid)
    
    _context.Add(newChef);
    _context.SaveChanges();
    return Index();
    
    // else
    // {
    //     return View("NewChef");
    // }
}

[HttpPost("/new/dish/create")]
public IActionResult createDish(Dish newDish)
{
    if(ModelState.IsValid)
    {
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    else
    {
        return View("NewDish");
    }
}













//Other routes=====================================
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
