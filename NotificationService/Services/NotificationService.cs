
using NotificationCommonLibrary;
using NotificationDomain.Entities;
using NotificationServices.DTOs;
using NotificationServices.Interfaces;

namespace NotificationServices.Services
{
    public class NotificationService : INotificationService
    {

        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task SendNotificationAsync(SendNotificationDto dto)
        {
            Status status = CommonLibrary.GetRandomEnumValue<Status>();
            var notification = new Notification
            {
                UserId = dto.UserId,
                NotificationTypeId = dto.NotificationTypeId,
                Channel = dto.Channel,
                Content = dto.Content,
                SentDate = DateTime.UtcNow,
                Status = status.ToString(),
            };

            await _notificationRepository.SendAsync(notification);
        }

        public async Task<NotificationStatusDto> GetNotificationStatusAsync(int notificationId)
        {
            var notification = await _notificationRepository.GetByIdAsync(notificationId);

            if (notification == null)
            {
                throw new Exception("Notification not found");
            }

            return new NotificationStatusDto { NotificationId = notificationId, Status = notification.Status };
        }

        public List<Notification> GetNotifications(int? userId, int? notificationTypeId, DateTime? from, DateTime? to)
        {
            var query = _notificationRepository.GetAll();

            if (userId.HasValue)
            {
                query = query.Where(n => n.UserId == userId.Value);
            }

            if (notificationTypeId.HasValue)
            {
                query = query.Where(n => n.NotificationTypeId == notificationTypeId.Value);
            }

            if (from.HasValue)
            {
                query = query.Where(n => n.SentDate >= from.Value);
            }

            if (to.HasValue)
            {
                query = query.Where(n => n.SentDate <= to.Value);
            }

            return [.. query];
        }
    }
}
