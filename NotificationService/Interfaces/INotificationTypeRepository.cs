using NotificationDomain.Entities;

namespace NotificationServices.Interfaces
{
    public interface INotificationTypeRepository
    {
        Task CreateAsync(NotificationType notificationType);
        Task UpdateAsync(NotificationType notificationType);
        Task DeleteAsync(int id);
        Task<NotificationType> GetByIdTypesAsync(int id);
        Task<IEnumerable<NotificationType>> GetAllTypesAsync();
    }
}
