using AutoMapper;
using BusinessSolutions.MVC.Models.Order;
using BusinessSolutions.OrderServices.BusinessLogic;
using BusinessSolutions.OrderServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessSolutions.MVC.Controllers
{
    [Route("/UpdateOrder")]
    [ApiVersion("1.0")]
    public class UpdateOrderController : Controller
    {
        private readonly IMapper mapper;
        private readonly ILogger<UpdateOrderController> _logger;
        private readonly IOrderService orderService;

        public UpdateOrderController(IMapper mapper, ILogger<UpdateOrderController> logger, IOrderService orderService)
        {
            this.mapper = mapper;
            _logger = logger;
            this.orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IndexAsync([FromRoute] int id)
        {
            var model  = await orderService.GetOrder(id);
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
    }
}
