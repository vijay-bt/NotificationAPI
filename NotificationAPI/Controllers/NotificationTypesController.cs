using Microsoft.AspNetCore.Mvc;
using NotificationDomain.Entities;
using NotificationServices.DTOs;
using NotificationServices.Interfaces;

namespace NotificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTypesController : ControllerBase
    {
        private readonly INotificationTypeService _notificationTypeService;
        public NotificationTypesController(INotificationTypeService notificationTypeService)
        {
            _notificationTypeService = notificationTypeService;
        }

        [HttpPost("CreateNotificationType")]
        public async Task<IActionResult> CreateNotificationType(CreateNotificationTypeDto dto)
        {
            NotificationType notificationType = await  _notificationTypeService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetNotificationType), new { id = notificationType.Id }, notificationType);
        }

        [HttpGet("GetNotificationType/{id}")]
        public async Task<IActionResult> GetNotificationType(int id)
        {
            var notificationType = await _notificationTypeService.GetByIdAsync(id);
            if (notificationType == null)
            {
                return NotFound();
            }
            return Ok(notificationType);
        }

        [HttpGet("GetNotificationTypes")]
        public async Task<IActionResult> GetNotificationTypes()
        {
            var notificationTypes = await _notificationTypeService.GetAllAsync();
            return Ok(notificationTypes);
        }

        [HttpPut("UpdateNotificationType/{id}")]
        public async Task<IActionResult> UpdateNotificationType(UpdateNotificationTypeDto updateNotificationTypeDto)
        {
            await _notificationTypeService.UpdateAsync(updateNotificationTypeDto);
            return NoContent();
        }

        [HttpDelete("DeleteNotificationType/{id}")]
        public async Task<IActionResult> DeleteNotificationType(int id)
        {
            await _notificationTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
