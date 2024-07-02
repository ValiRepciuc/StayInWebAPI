using StayIn.DTO.Country;
using StayInAPI.Models;

namespace StayIn.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountryAsync();
        Task<Country> GetCountryByIdAsync(int id);
        Task<Country> AddCountryAync(Country country);
        Task<Country> UpdateCountryAync(CountryDto countryDto, int id);
        Task<bool> DeleteCoutryAsync(int id);
        Task<bool> CountryExistsAsync(int id);
    }
}
