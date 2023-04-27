using Microsoft.AspNetCore.Mvc;
namespace RenderingViews.Controllers; 

public class SurveyController: Controller
{
    [HttpGet("")]
    public ViewResult Show()
    {
        return View("Main");
    }
    [HttpPost("Fillout")]
    public IActionResult Fillout(string Name, string dojo, string Lang, string Comment )
    {
        HttpContext.Session.SetString("Name", $"{Name}");
        HttpContext.Session.SetString("Location", $"{dojo}");
        HttpContext.Session.SetString("Lang", $"{Lang}");
        HttpContext.Session.SetString("Comment", $"{Comment}");
        return RedirectToAction ("show");
    }
    [HttpGet("result")]
    public ViewResult show()
    {
        return View("show");
    }

}