using NotificationDomain.Entities;
using NotificationServices.DTOs;

namespace NotificationServices.Interfaces
{
    public interface INotificationTypeService
    {
        Task<NotificationType> CreateAsync(CreateNotificationTypeDto createNotificationTypeDto);
        Task UpdateAsync(UpdateNotificationTypeDto updateNotificationTypeDto);
        Task DeleteAsync(int id);
        Task<NotificationType> GetByIdAsync(int id);
        Task<IEnumerable<NotificationType>> GetAllAsync();
    }
}
