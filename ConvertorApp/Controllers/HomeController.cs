using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConvertorApp.Models;
using ConvertorApp.Data;

namespace ConvertorApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    HttpManager m = new HttpManager();
    public HomeController(ILogger<HomeController> logger)
    {
        HttpManager m = new HttpManager();
        
        _logger = logger;
    }

    public IActionResult Index()
    {
        SymbolsDto x = m.GetDataFromApi<SymbolsDto>("symbols").Result;
        return View(x);
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
