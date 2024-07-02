using StayIn.DTO.Adress;
using StayInAPI.Models;

namespace StayIn.Interfaces
{
    public interface IAdressRepository
    {
        Task<IEnumerable<Adress>> GetAdressAsync();
        Task<Adress> GetAdressByIdAsync(int id);
        Task<Adress> AddAdressAsync(Adress adress);
        Task<Adress> UpdateAdressAsync(int id, AdressDto adressDto);
        Task<bool> DeleteAdressAsync(int id);
        Task<bool> AdressExistsAsync(int id);
    }
}
