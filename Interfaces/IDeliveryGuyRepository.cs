using StayIn.DTO.Delivery_GuyDto;
using StayInAPI.Models;

namespace StayIn.Interfaces
{
    public interface IDeliveryGuyRepository
    {
        Task<IEnumerable<Delivery_Guy>> GetDeliveryGuysAsync();
        Task<Delivery_Guy> GetDeliveryGuyByIdAsync(int id);
        Task<Delivery_Guy> AddDeliveryGuyAsync(Delivery_Guy deliveryGuy);
        Task<Delivery_Guy> UpdateDeliveryGuyAsync(Delivery_GuyDto deliveryGuyDto, int id);
        Task<bool> DeleteDeliveryGuyAsync(int id);
        Task<bool> DeliveryGuyExistsAsync(int id);
    }
}
