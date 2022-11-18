using AutoMapper;
using BusinessSolutions.Data.Entities;
using BusinessSolutions.MVC.Models.Order;
using BusinessSolutions.MVC.Models.OrderItem;
using BusinessSolutions.MVC.Models.Provider;
using BusinessSolutions.OrderItemServices.BusinessLogic;
using BusinessSolutions.OrderItemServices.Models;
using BusinessSolutions.OrderServices.BusinessLogic;
using BusinessSolutions.OrderServices.Models;
using BusinessSolutions.ProviderServices.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BusinessSolutions.MVC.Controllers;

[Route("UpdateOrder")]
[ApiVersion("1.0")]
public class UpdateOrderController : Controller
{
    private readonly IMapper mapper;
    private readonly ILogger<UpdateOrderController> logger;
    private readonly IOrderService orderService;
    private readonly IProviderService providerService;
    private readonly IOrderItemService orderItemService;

    public UpdateOrderController(IMapper mapper, ILogger<UpdateOrderController> logger, IOrderService orderService, IProviderService providerService, IOrderItemService orderItemService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.orderService = orderService;
        this.providerService = providerService;
        this.orderItemService = orderItemService;
    }

    [HttpGet("")]
    public async Task<IActionResult> IndexAsync(int id)
    {       
        
        var model = await orderService.GetOrder(id);
        var response = mapper.Map<OrderResponse>(model);

        var itemsModels = await orderItemService.GetOrderItemsByOrderId(id);
        var items = (itemsModels.ToList()).Select(order => mapper.Map<OrderItemResponse>(order));

        response.Content = items.ToList();

        return View("UpdateOrder", response);
    }

    [HttpPost("update/")]
    public async Task<IActionResult> Update( int id, int providerid, string number, string date, IEnumerable<AddOrUpdateOrderItemRequest> content) 
    {
        //UpdateOrderRequest request = new UpdateOrderRequest()
        //{
        //    ProviderId = providerid,
        //    Number = number,
        //    Date = Convert.ToDateTime(date),
        //};
        //var model = mapper.Map<UpdateOrderModel>(request);
        //await orderService.UpdateOrder(id,model);

        var itemsModels = (content.ToList()).Select(order => mapper.Map<AddOrUpdateOrderItemModel>(order));
        await orderItemService.AddOrUpdateOrderItem(itemsModels);
        

        return Ok();
    }

    [HttpGet("getproviders/")]
    public async Task<IEnumerable<ProviderResponse>> GetProviders()
    {
        var models = await providerService.GetProviders();
        var response = mapper.Map<IEnumerable<ProviderResponse>>(models);
        return response;
    }
}
