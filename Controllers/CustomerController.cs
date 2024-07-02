using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayIn.DTO.Customer;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ApplicationDbContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCustomers()
        {
            var customer = await _customerRepository.GetCustomerAsync();
            return Ok(customer);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCustomer(string id) {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = $"Clientul cu id-ul {id} nu exista" });
            }
            return Ok(customer);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCustomer([FromBody]CustomerDto customer, string id)
        {
            var customerModel = _context.Customer.FirstOrDefault(x => x.Id == id);
            if(customerModel == null)
            {
                return NotFound(new { message = "Clientul nu a fost gasit" });

            }

            customerModel.FirstName = customer.FirstName;
            customerModel.LastName = customer.LastName;

            _context.SaveChanges();
            return Ok(new { message = $"Clientul cu id-ul {id} s-a modificat cu succes" });

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var customerExists = await _customerRepository.CustomerExistsAsync(id);
            if (!customerExists)
            {
                return NotFound(new { message = "Clientul nu a fost gasit" });
            }
            await _customerRepository.DeleteCustomerAsync(id);
            return Ok(new { message = "Clientul s-a sters cu succes" });
        }
    }
}
