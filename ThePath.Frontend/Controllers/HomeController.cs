using Microsoft.AspNetCore.Mvc;
using ThePath.Frontend.Models.Classes;
using ThePath.Frontend.Models.Classes.Dto;
using ThePath.Frontend.Models.Classes.Vm;
using ThePath.Frontend.Services.Interfaces;

namespace ThePath.Frontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISendMailToAurhorEmail _sendMailToAurhorEmail;
    private readonly IEntertainmentService _entertainmentService;
    private readonly IWebHostEnvironment _appEnvironment;
    public HomeController(ILogger<HomeController> logger, ISendMailToAurhorEmail sendMailToAurhorEmail,
        IEntertainmentService entertainmentService, IWebHostEnvironment appEnvironment)
    {
        _entertainmentService = entertainmentService;
        _logger = logger;
        _sendMailToAurhorEmail = sendMailToAurhorEmail;
        _appEnvironment = appEnvironment;
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
        //TO DO REFACTORING ALL METHOD WARNING
        //to (never) do kill temporally mock

        bool isHavePrice = pickPriceDto.TypeEntertainment != Models.Enum.TypeEntertainment.Attraction
            && pickPriceDto.TypeEntertainment != Models.Enum.TypeEntertainment.InterestingPlacesInTomsk
            && pickPriceDto.TypeEntertainment != Models.Enum.TypeEntertainment.Cinema
            && pickPriceDto.TypeEntertainment != Models.Enum.TypeEntertainment.EntertainmentForChildren
            && pickPriceDto.TypeEntertainment != Models.Enum.TypeEntertainment.HorseRides;

        PickPriceVm pickPriceVm = new();
        pickPriceVm.TypeEntertainment = pickPriceDto.TypeEntertainment;

        if (isHavePrice == false)
        {
            pickPriceVm.IntervalMoney = Models.Enum.IntervalMoney.More;
            pickPriceVm.Price = 0;

            return RedirectToAction("PickArea", pickPriceVm);
        }

        if (pickPriceDto.TypeEntertainment == Models.Enum.TypeEntertainment.CafesAndRestaurants)
            pickPriceVm.Price = 1000;

        if (pickPriceDto.TypeEntertainment == Models.Enum.TypeEntertainment.RecreationCenters)
            pickPriceVm.Price = 7000;

        if (pickPriceDto.TypeEntertainment == Models.Enum.TypeEntertainment.Saunas)
            pickPriceVm.Price = 1000;

        return View(pickPriceVm);
    }

    [HttpGet]
    public IActionResult PickArea(PickPriceVm pickPriceVm)
    {
        return View(pickPriceVm);
    }

    [HttpGet]
    public async Task<IActionResult> ResultListEntertainment(EntertainmentServiceGetListByTypeAndAreaAndPriceDto dto)
    {
        var res = await _entertainmentService.GetEntertainmentListByTypeAndAreaAndPriceAsync(dto);
        return View(res);
    }

    [HttpGet]
    public async Task<IActionResult> DetailsEntertainment(EntertainmentServiceGetDto dto)
    {
        ViewBag.PathWwwRoot  = _appEnvironment.WebRootPath;
        var res = await _entertainmentService.GetEntertainmentAsync(dto);
        return View(res);
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

    [HttpGet]
    public IActionResult Policy()
    {
        return View();
    }
}

