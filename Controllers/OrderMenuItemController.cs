using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayIn.DTO.Order_Menu_Items;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMenuItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderMenuItemRepository _repository;

        public OrderMenuItemController(ApplicationDbContext context, IOrderMenuItemRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOrderMenuItems()
        {
            var orderItems = await _repository.GetAllAsync();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetOrderMenuItem(int id)
        {
            var orderItem = await _repository.GetByIdASync(id);
            if(orderItem == null)
            {
                return NotFound(new { message = $"Item-ul comandat cu id-ul {id} nu exista" });
            }
            return Ok(orderItem);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostOrderMenuItem([FromBody]Order_Menu_Item item)
        {
            var createdOrderItem = await _repository.AddAsync(item);
            return CreatedAtAction(nameof(GetOrderMenuItem), new { id = createdOrderItem.Id }, createdOrderItem);
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutOrderMenuItem([FromBody]Order_Menu_ItemsDto item, int id)
        {
           var itemModel = _context.Order_Menu_Item.FirstOrDefault(x => x.Id == id);
            if(itemModel == null)
            {
                return NotFound(new { message = "Item-ul comandat nu a fost gasit" });
            }

            itemModel.QtyOrdered = item.QtyOrdered;
            itemModel.OrderId = item.OrderId;
            itemModel.MenuItemId = item.MenuItemId;

            _context.SaveChanges();
            return Ok(new { message = $"Item-ul comandat cu id-ul {id} s-a modificat cu succes" });

        }

    }
}