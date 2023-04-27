using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojosurveyWVals.Models;

namespace DojosurveyWVals.Controllers;

public class HomeController : Controller
{
    static Survey survey;
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
[HttpPost("process")]
    public IActionResult Privacy(Survey newSurvey)
    {
        if(ModelState.IsValid)
        {
        }
        else{

        return View("index");
        }
        survey = newSurvey;
        System.Console.WriteLine(survey.Comment);
        return RedirectToAction("Display");
    }

    [HttpGet("display")]
    public IActionResult Display()
    {
        return View("display", survey);
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
