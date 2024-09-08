using NotificationDomain.Entities;

namespace NotificationServices.DTOs
{
    public class SendNotificationDto
    {
        public int UserId { get; set; }
        public int NotificationTypeId { get; set; }
        public Channel Channel { get; set; }
        public string? Content { get; set; }
    }
}
