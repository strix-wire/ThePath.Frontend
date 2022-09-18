using Microsoft.AspNetCore.Mvc;

namespace ThePath.Frontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();
    }
}

