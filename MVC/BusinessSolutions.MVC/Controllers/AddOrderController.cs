using AutoMapper;
using BusinessSolutions.MVC.Models.Order;
using BusinessSolutions.OrderServices.BusinessLogic;
using BusinessSolutions.OrderServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessSolutions.MVC.Controllers;

[Route("AddOrder")]
[ApiVersion("1.0")]
public class AddOrderController : Controller
{
    private readonly IMapper mapper;
    private readonly ILogger<AddOrderController> _logger;
    private readonly IOrderService orderService;

    public AddOrderController(IMapper mapper, ILogger<AddOrderController> logger, IOrderService orderService)
    {
        this.mapper = mapper;
        _logger = logger;
        this.orderService = orderService;
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
}
