using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUD.Models;

namespace CRUD.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context; 

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context = context;
    }
[HttpGet("")]
public IActionResult Index()
    {
        List<Dish>dishes = _context.Dishes.OrderBy(d => d.Name).ToList();
        return View("Index", dishes);
    }

    [HttpGet("/new/dish")]
    public IActionResult CreateForm()
    {
        return View("CreateDish");
    }

[HttpPost("/create/dish")]
public IActionResult MakeDish(Dish newDish)
{
    if(ModelState.IsValid)
    {
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    else
    {
    return CreateForm();
    }
}

[HttpGet("/render/{DishID}/dish")]
public IActionResult Updatedish(int DishID)

{
    Dish? EditDish = _context.Dishes.FirstOrDefault(d =>d.DishId == DishID);
    return View("EditDish", EditDish);
}

[HttpPost("/edit/{DishID}/dish")]
public IActionResult editDish(Dish editedDish, int DishID)

{
    Dish? EditDish = _context.Dishes.FirstOrDefault(d =>d.DishId == DishID);
    if(ModelState.IsValid){
        EditDish.Chef = editedDish.Chef;
        EditDish.Name = editedDish.Name;
        EditDish.Tasiness = editedDish.Tasiness;
        EditDish.Calories = editedDish.Calories;
        EditDish.Description = editedDish.Description;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    else
    {
        return View("EditDish",EditDish);
    }
}

[HttpPost("/delete/{DishID}/dish")]
public IActionResult Delete(int DishID)
{
    Dish? EditDish = _context.Dishes.SingleOrDefault(d =>d.DishId == DishID);
    _context.Dishes.Remove(EditDish);
    _context.SaveChanges();
    return RedirectToAction("Index");
}

[HttpGet("/{DishID}/dish")]
public IActionResult ViewOne(int DishID)
{
    Dish? ViewoneDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishID);
    return View("ViewOneDish", ViewoneDish);

}
















//End routes
[HttpGet()]

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
