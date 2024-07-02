using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayIn.DTO.Delivery_GuyDto;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryGuyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IDeliveryGuyRepository _deliveryGuyRepository;

        public DeliveryGuyController(ApplicationDbContext context, IDeliveryGuyRepository deliveryGuyRepository)
        {
            _context = context;
            _deliveryGuyRepository = deliveryGuyRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDeliveryGuys()
        {
            var deliveryGuys = await _deliveryGuyRepository.GetDeliveryGuysAsync();
            return Ok(deliveryGuys);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryGuy(int id)
        {
            var deliveryGuy = await _deliveryGuyRepository.GetDeliveryGuyByIdAsync(id);
            if(deliveryGuy == null)
            {
                return NotFound(new { message = $"Livratorul cu id-ul {id} nu exista" });
            }
            return Ok(deliveryGuy);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostDelvieryGuy([FromBody]Delivery_Guy deliveryGuy)
        {
            var createdDeliveryGuy = await _deliveryGuyRepository.AddDeliveryGuyAsync(deliveryGuy);
            return CreatedAtAction(nameof(GetDeliveryGuy), new { id = createdDeliveryGuy.DeliveryGuyId }, createdDeliveryGuy);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutDelvieryGuy([FromBody]Delivery_GuyDto deliveryGuy, int id)
        {
            var deliveryGuyModel = _context.Delivery_Guy.FirstOrDefault(x => x.DeliveryGuyId == id);
            if(deliveryGuyModel == null)
            {
                return NotFound(new { message = "Livratorul nu a fost gasit" });
            }

            deliveryGuyModel.Name = deliveryGuy.Name;
            deliveryGuyModel.Number = deliveryGuy.Number;

            _context.SaveChanges();
            return Ok(new { message = $"Livratorul cu id-ul {id} s-a modificat cu succes" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDeliveryGuy(int id)
        {
            var deliveryGuyExists = await _deliveryGuyRepository.DeliveryGuyExistsAsync(id);
            if (!deliveryGuyExists)
            {
                return NotFound(new { message = $"Livratorul nu a fost gasit" });
            }
            await _deliveryGuyRepository.DeleteDeliveryGuyAsync(id);
            return Ok(new { message = "Livratorul s-a sters cu succes!" });
        }
    }
}