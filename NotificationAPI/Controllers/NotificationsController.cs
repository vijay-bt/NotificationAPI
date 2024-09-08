using Microsoft.AspNetCore.Mvc;
using NotificationServices.DTOs;
using NotificationServices.Interfaces;

namespace NotificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("SendNotification")]
        public async Task<IActionResult> SendNotification(SendNotificationDto dto)
        {
            await _notificationService.SendNotificationAsync(dto);
            return Ok("Notification Sent");
        }

        [HttpGet("GetNotificationStatus/{id}")]
        public async Task<IActionResult> GetNotificationStatus(int id)
        {
            var status = await _notificationService.GetNotificationStatusAsync(id);
            return Ok(status);
        }

        [HttpGet("GetNotifications")]
        public IActionResult GetNotifications([FromQuery] int? userId, [FromQuery] int? notificationTypeId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var notifications = _notificationService.GetNotifications(userId, notificationTypeId, from, to);
            return Ok(notifications);
        }
    }
}
