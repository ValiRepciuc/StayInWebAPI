using StayInAPI.Models;

namespace StayIn.Interfaces
{
    public interface ICustomer_AdressRepository
    {
        Task<IEnumerable<Customer_Adress>> GetCustomerAdressesAsync();
        Task<Customer_Adress> GetCustomerAdressByIdAsync(int id);
        Task<Customer_Adress> AddCustomerAdressAsync(Customer_Adress customer_adress);
        Task<Customer_Adress> UpdateCustomerAdressAsync(int id, Customer_Adress customer_adress);
        Task<bool> DeleteCustomerAdressAsync(int id);
        Task<bool> CustomerAdressExistsAsync(int id);

        
    }
}
