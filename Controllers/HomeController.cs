using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using admin_cms.Models;

namespace admin_cms.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Message = this.HttpContext.Session.GetString("Alunos");
        return View();
    }

    public IActionResult Privacy()
    {
        this.HttpContext.Session.SetString("Alunos","Torne-se um Programador");


        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
