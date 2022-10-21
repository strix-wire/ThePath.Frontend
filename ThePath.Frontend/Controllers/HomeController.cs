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
    public HomeController(ILogger<HomeController> logger, ISendMailToAurhorEmail sendMailToAurhorEmail,
        IEntertainmentService entertainmentService)
    {
        _entertainmentService = entertainmentService;
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
        //call entertainmentService to get average price by entertainment
        
        PickPriceVm pickPriceVm = new();
        pickPriceVm.Price = 300;
        pickPriceVm.TypeEntertainment = pickPriceDto.TypeEntertainment;

        return View(pickPriceVm);
    }

    [HttpGet]
    public IActionResult PickArea(PickPriceVm pickPriceVm)
    {
        return View(pickPriceVm);
    }

    //[HttpGet]
    //public async Task<IActionResult> EntertainmentDetails(Guid id)
    //{
    //    bool result = await _entertainmentService.GetEntertainmentAsync(new EntertainmentServiceGetDto { Id = id });

    //    return View();
    //}

    [HttpGet]
    public async Task<IActionResult> ResultListEntertainment(EntertainmentServiceGetListByTypeAndAreaAndPriceDto dto)
    {
        var res = await _entertainmentService.GetEntertainmentListByTypeAndAreaAndPriceAsync(dto);
        return View(res);
    }

    [HttpGet]
    public async Task<IActionResult> DetailsEntertainment(EntertainmentServiceGetDto dto)
    {
        var res = await _entertainmentService.GetEntertainmentAsync(dto);
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

