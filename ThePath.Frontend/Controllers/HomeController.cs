using Microsoft.AspNetCore.Mvc;

namespace ThePath.Frontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogTrace("Request to \"Index\" successful");

        return View();
    }

    [HttpGet]
    public IActionResult PickEntertainment()
    {
        _logger.LogTrace("Request to \"PickEntertainment\" successful");

        return View();
    }
}

