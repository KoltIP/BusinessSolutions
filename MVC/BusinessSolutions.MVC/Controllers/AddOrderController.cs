using AutoMapper;
using BusinessSolutions.MVC.Models.Order;
using BusinessSolutions.MVC.Models.Provider;
using BusinessSolutions.OrderServices.BusinessLogic;
using BusinessSolutions.OrderServices.Models;
using BusinessSolutions.ProviderServices.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BusinessSolutions.MVC.Controllers;

[Route("AddOrder")]
[ApiVersion("1.0")]
public class AddOrderController : Controller
{
    private readonly IMapper mapper;
    private readonly ILogger<AddOrderController> _logger;
    private readonly IOrderService orderService;
    private readonly IProviderService providerService;

    public AddOrderController(IMapper mapper, ILogger<AddOrderController> logger, IOrderService orderService, IProviderService providerService)
    {
        this.mapper = mapper;
        _logger = logger;
        this.orderService = orderService;
        this.providerService = providerService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View("AddOrder");
    }

    public async Task<IActionResult> Add(AddOrderRequest request)
    {
        var model = mapper.Map<AddOrderModel>(request);
        await orderService.AddOrder(model);
        return Redirect("/");
    }

    [HttpGet("getproviders/")]
    public async Task<IEnumerable<ProviderResponse>> GetProviders()
    {
        var models = await providerService.GetProviders();
        var response = mapper.Map<IEnumerable<ProviderResponse>>(models);
        return response;
    }

}
