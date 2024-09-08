namespace NotificationDomain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int NotificationTypeId { get; set; }
        public Channel Channel { get; set; }
        public string? Content { get; set; }
        public DateTime SentDate { get; set; }
        public string? Status { get; set; }

        public NotificationType? NotificationType { get; set; }
    }
}
