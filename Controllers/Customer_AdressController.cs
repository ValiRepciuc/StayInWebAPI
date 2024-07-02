using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Controllers
{
    [Route("api/customeradress")]
    [ApiController]
    public class Customer_AdressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomer_AdressRepository _customerAdressRepository;

        public Customer_AdressController(ApplicationDbContext context, ICustomer_AdressRepository customerAdressRepository)
        {
            _context = context;
            _customerAdressRepository = customerAdressRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCustomerAdresses()
        {
            var customerAdresses = await _customerAdressRepository.GetCustomerAdressesAsync();
            return Ok(customerAdresses);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCustomerAdress(int id)
        {
            var customerAdress = await _customerAdressRepository.GetCustomerAdressByIdAsync(id);

            if (customerAdress == null)
            {
                return NotFound(new { message = $"Adresa utilizatorului cu id-ul {id} nu exista" });
            }

            return Ok(customerAdress);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostCustomerAdress([FromBody] Customer_Adress customer_adress)
        {
            var createdCustomerAdress = await _customerAdressRepository.AddCustomerAdressAsync(customer_adress);
            return CreatedAtAction("GetCustomerAdress", new { id = createdCustomerAdress.CaId }, createdCustomerAdress);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCustomerAdress([FromBody]Customer_Adress customer_adress, int id)
        {
            if (id != customer_adress.CaId)
            {
                return BadRequest(new { message = "Id-ul furnizat pentru aceasta adresa este invalid!" });
            }

            var updatedCustomerAdress = await _customerAdressRepository.UpdateCustomerAdressAsync(id, customer_adress);
            if (updatedCustomerAdress == null)
            {
                return NotFound(new { message = "Adresa nu a fost gasita!" });
            }
            return Ok(new { message = $"Adresa cu id-ul {id} s-a modificat cu succes" });
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCustomerAdress(int id)
        {
            var customerAdressExists = await _customerAdressRepository.CustomerAdressExistsAsync(id);
            if (!customerAdressExists)
            {
                return NotFound(new { message = $"Adresa cu id-ul {id} nu a fost gasita!" });
            }
            await _customerAdressRepository.DeleteCustomerAdressAsync(id);
            return Ok(new { message = "Adresa s-a sters cu succes!" });
        }

    }
}
