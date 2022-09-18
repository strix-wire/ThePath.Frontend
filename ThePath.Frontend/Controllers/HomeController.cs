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
        _logger.LogTrace("Request to index successful");
        return View();
    }
}

