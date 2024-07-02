using StayIn.DTO.Customer;
using StayInAPI.Models;

namespace StayIn.Interfaces
{
    public interface ITokenService
    {
       string CreateToken(Customer customer);
        String CreateTokenx2(CustomerDto customer, TimeSpan tokenLifetime);
    }
}
