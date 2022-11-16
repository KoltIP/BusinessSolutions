using AutoMapper;
using BusinessSolutions.MVC.Models.Order;
using BusinessSolutions.MVC.Models.Provider;
using BusinessSolutions.OrderServices.BusinessLogic;
using BusinessSolutions.OrderServices.Models;
using BusinessSolutions.ProviderServices.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BusinessSolutions.MVC.Controllers;

[Route("/UpdateOrder")]
[ApiVersion("1.0")]
public class UpdateOrderController : Controller
{
    private readonly IMapper mapper;
    private readonly ILogger<UpdateOrderController> logger;
    private readonly IOrderService orderService;
    private readonly IProviderService providerService;

    public UpdateOrderController(IMapper mapper, ILogger<UpdateOrderController> logger, IOrderService orderService, IProviderService providerService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.orderService = orderService;
        this.providerService = providerService;
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> IndexAsync([FromRoute] int id)
    //{
    //    var model  = await orderService.GetOrder(id);
    //    var response = mapper.Map<OrderResponse>(model);
    //    return View("UpdateOrder", response);
    //}

    [HttpGet("")]
    public async Task<IActionResult> IndexAsync(int id)
    {
        var model = await orderService.GetOrder(id);
        var response = mapper.Map<OrderResponse>(model);
        return View("UpdateOrder", response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderRequest request)
    {
        var model = mapper.Map<UpdateOrderModel>(request);
        await orderService.UpdateOrder(id,model);
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
