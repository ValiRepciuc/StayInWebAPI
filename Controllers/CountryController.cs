using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayIn.DTO.Country;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICountryRepository _countryRepository;

        public CountryController(ApplicationDbContext context, ICountryRepository countryRepository)
        {
            _context = context;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryRepository.GetCountryAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCountry(int id)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id);
            if(country == null)
            {
                return NotFound(new { message = $"Tara cu id-ul {id} nu exista" });
            }
            return Ok(country);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostCountry([FromBody]Country country)
        {
            var createdCountry = await _countryRepository.AddCountryAync(country); 
            return CreatedAtAction(nameof(PostCountry), new {id = createdCountry.CountryId}, createdCountry);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCountry([FromBody]CountryDto country, int id)
        {
            var countryModel = _context.Country.FirstOrDefault(x => x.CountryId == id);
            if(countryModel == null)
            {
                return NotFound(new { message = "Tara nu a fost gasita" });
            }
            countryModel.Name = country.Name;

            _context.SaveChanges();
            return Ok(new { message = $"Tara cu id-ul {id} s-a modificat cu succes" });
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var countryExists = await _countryRepository.CountryExistsAsync(id);
            if (!countryExists)
            {
                return NotFound(new { message = $"Tara cu id-ul {id} nu a fost gasita" });
            }
            await _countryRepository.DeleteCoutryAsync(id);
            return Ok(new { message = "Tara s-a sters cu succes!" });
        }
    }
}
