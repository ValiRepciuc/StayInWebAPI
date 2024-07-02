using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayIn.DTO.Adress;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Controllers
{
    [Route("api/adress")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdressRepository _adressRepository;

        public AdressController(ApplicationDbContext context, IAdressRepository adressRepository)
        {
            _context = context;
            _adressRepository = adressRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAdresses()
        {
            var adresses = await _adressRepository.GetAdressAsync();
            return Ok(adresses);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAdress(int id)
        {
            var adress = await _adressRepository.GetAdressByIdAsync(id);

            if(adress == null)
            {
                return NotFound(new { message = $"Adresa cu id-ul {id} nu exista" });
            }

            return Ok(adress);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAdress([FromBody]Adress adress)
        {
            var createdAdress = await _adressRepository.AddAdressAsync(adress);
            return CreatedAtAction("GetAdress", new { id = createdAdress.AdressId }, createdAdress);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutAdress(int id, AdressDto adress)
        {
            var adressModel = _context.Adress.FirstOrDefault(x=>x.AdressId == id);
            if(adressModel == null)
            {
                return NotFound(new { message = "Adresa nu a fost gasita" });
            }
            adressModel.StreetNumber = adress.StreetNumber;
            adressModel.ZIP = adress.ZIP;
            adressModel.City = adress.City;
            adressModel.Region = adress.Region;

            _context.SaveChanges();
            return Ok(new { message = $"Adresa cu id-ul {id} s-a modificat cu succes!" });
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            var adressExists = await _adressRepository.AdressExistsAsync(id);
            if (!adressExists)
            {
                return NotFound(new {message = "Adresa nu a fost gasita"});
            }
            await _adressRepository.DeleteAdressAsync(id);
            return Ok(new { message = "Adresa s-a sters cu succes!" });
        }
    }
}
