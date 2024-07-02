using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StayIn.DTO.Order;
using StayInAPI.Data;
using StayInAPI.Models;
using StayInAPI.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StayInAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderRepository _orderRepository;

        public OrdersController(ApplicationDbContext context, IOrderRepository orderRepository)
        {
            _context = context;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return Ok(order);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostOrder([FromBody] Order order)
        {
            var createdOrder = await _orderRepository.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.OrderID }, createdOrder);
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutOrder([FromBody] Order order, int id)
        {
            var orderModel = _context.Order.FirstOrDefault(x => x.OrderID == id);
            if(orderModel == null)
            {
                return NotFound(new { message = "Comanda nu a fost gasita" });
            }

            orderModel.Number = order.Number;
            orderModel.Date = order.Date;
            orderModel.CustomerId = order.CustomerId;
            orderModel.RestaurantId = order.RestaurantId;
            orderModel.DeliveryGuyId = order.DeliveryGuyId;
            orderModel.CustomerAdressId = order.CustomerAdressId;

            _context.SaveChanges();
            return Ok(new { message = $"Comanda cu id-ul {id} s-a modificat cu succes" });

        }
    }
}