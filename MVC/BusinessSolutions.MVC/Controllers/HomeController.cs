using AutoMapper;
using BusinessSolutions.MVC.Models;
using BusinessSolutions.MVC.Models.Order;
using BusinessSolutions.OrderServices;
using BusinessSolutions.OrderServices.BusinessLogic;
using BusinessSolutions.OrderServices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BusinessSolutions.MVC.Controllers
{
    [Route("")]
    [ApiVersion("1.0")]
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService orderService;

        public HomeController(IMapper mapper, ILogger<HomeController> logger, IOrderService orderService)
        {
            this.mapper = mapper;
            _logger = logger;
            this.orderService = orderService;
        }

        [HttpGet("")]
        public async Task<IActionResult> IndexAsync()
        {
            var models = await orderService.GetOrders();
            IEnumerable<OrderResponse> response = mapper.Map<IEnumerable<OrderResponse>>(models);
            return View("Index", response);
        }

        [HttpGet("filter/")]
        public async Task<IEnumerable<OrderResponse>> Filter(int provider, string startDate, string endDate)
        {
            var filteredModels = await orderService.FilterOrders(provider,startDate,endDate);
            IEnumerable<OrderResponse> filteredResponse = mapper.Map<IEnumerable<OrderResponse>>(filteredModels);
            return filteredResponse;
        }
         
        [HttpGet("getorders")]
        public async Task<IEnumerable<OrderResponse>> GetOrders()
        {
            var models = await orderService.GetOrders();
            var response = mapper.Map<IEnumerable<OrderResponse>>(models);
            return response;
        }    

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            await orderService.DeleteOrder(id);            
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}