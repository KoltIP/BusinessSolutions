using AutoMapper;
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

[Route("AddOrder")]
[ApiVersion("1.0")]
public class AddOrderController : Controller
{
    private readonly IMapper mapper;
    private readonly ILogger<AddOrderController> logger;
    private readonly IOrderService orderService;
    private readonly IProviderService providerService;
    private readonly IOrderItemService orderItemService;

    public AddOrderController(IMapper mapper, ILogger<AddOrderController> logger, IOrderService orderService, IProviderService providerService, IOrderItemService orderItemService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.orderService = orderService;
        this.providerService = providerService;
        this.orderItemService = orderItemService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View("AddOrder");
    }


    [HttpPost("add/")]
    public async Task<IActionResult> Add(int providerId, string number, string date, IEnumerable<AddOrderItemRequest> content)
    {        
        AddOrderRequest request = new AddOrderRequest()
        {
            Number = number,
            ProviderId = providerId,
            Date = Convert.ToDateTime(date),            
        };
        var model = mapper.Map<AddOrderModel>(request);
        var order = mapper.Map<OrderResponse>(await orderService.AddOrder(model));

        foreach (var contentElem in content)
        {
            AddOrderItemRequest item = new AddOrderItemRequest()
            {
                Name = contentElem.Name,
                Quantity = contentElem.Quantity,
                Unit = contentElem.Unit,
                OrderId = order.Id
            };
            var itemModel = mapper.Map<AddOrderItemModel>(item);
            await orderItemService.AddOrderItem(order.Id,itemModel);
        }

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
