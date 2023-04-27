using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PandC.Models;
namespace PandC.Controllers;    

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        CallModel callM = new CallModel()
        {
            ViewP = _context.Ps.ToList(),
            P = new P()
        };
        return View(callM);
    }

// ********************Get's
[HttpGet("category")]
public IActionResult GetCat()
{
            CallModel callMTwo = new CallModel()
        {
            ViewC = _context.Cs.ToList(),
            C = new C()
        };
        return View(callMTwo);
}
[HttpGet()]
public IActionResult GetProdbyID(int ProductId)
{
    List<C> cs = _context.Cs.ToList();
    P P = _context.Ps.First(p => p.ProductId == ProductId);
    var ProducthasCats = _context.Joins.Include(z=> z.C).Where(z =>z.ProductId == P.ProductId).Select(z => z.C);
    CallModel callModelthree = new CallModel
    {
        ViewP
    }


}
[HttpGet()]
public IActionResult GetCatbyID()
{

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
