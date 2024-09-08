using NotificationDomain.Entities;

namespace NotificationServices.Interfaces
{
    public interface INotificationRepository
    {
        IQueryable<Notification> GetAll();
        Task<Notification> GetByIdAsync(int id);
        Task<IEnumerable<Notification>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Notification>> GetByTypeAsync(int typeId);
        Task SendAsync(Notification notification);
        Task UpdateAsync(Notification notification);
        Task DeleteAsync(int id);
    }
}
