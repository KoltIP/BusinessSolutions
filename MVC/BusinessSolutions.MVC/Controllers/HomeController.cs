﻿using AutoMapper;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getorder/{id}")]
        public async Task<OrderResponse> GetOrder([FromRoute] int id)
        {
            OrderModel model = await orderService.GetOrder(id);
            OrderResponse response = mapper.Map<OrderResponse>(model);
            return response;
        }

        [HttpGet("getorders")]
        public async Task<IEnumerable<OrderResponse>> GetOrders()
        {
            var models = await orderService.GetOrders();
            var response = mapper.Map<IEnumerable<OrderResponse>>(models);
            return response;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder([FromRoute] AddOrderModel addOrderModel)
        {
            await orderService.AddOrder(addOrderModel);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateOrderModel updateOrderModel)
        {
            await orderService.UpdateOrder(id, updateOrderModel);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            await orderService.DeleteOrder(id);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}