using NotificationDomain.Entities;
using NotificationServices.DTOs;

namespace NotificationServices.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(SendNotificationDto dto);
        Task<NotificationStatusDto> GetNotificationStatusAsync(int notificationId);
        List<Notification> GetNotifications(int? userId, int? notificationTypeId, DateTime? from, DateTime? to);
    }
}
