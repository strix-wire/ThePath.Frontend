using Microsoft.AspNetCore.Mvc;
using ThePath.Frontend.Models.Classes;
using ThePath.Frontend.Models.Enum;
using ThePath.Frontend.Services.Interfaces;

namespace ThePath.Frontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISendMailToAurhorEmail _sendMailToAurhorEmail;
    public HomeController(ILogger<HomeController> logger, ISendMailToAurhorEmail sendMailToAurhorEmail)
    {
        _logger = logger;
        _sendMailToAurhorEmail = sendMailToAurhorEmail;
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogTrace("Request to \"Index\" successful");

        return View();
    }

    [HttpGet]
    public IActionResult PickTypeEntertainment()
    {
        _logger.LogTrace("Request to \"PickTypeEntertainment\" successful");

        return View();
    }

    [HttpGet]
    public IActionResult PickPrice(PickPriceDto pickPriceDto)
    {
        return View();
    }

    [HttpGet]
    public IActionResult PickArea(PickAreaDto PickAreaDto)
    {
        return View();
    }

    [HttpGet]
    public IActionResult ContactWithAdmin()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SuccessfullSendEmail(MailToAuthorEmailDto mail)
    {
        Task<bool> result = _sendMailToAurhorEmail.SendAsync(mail);

        return View();
    }
}

