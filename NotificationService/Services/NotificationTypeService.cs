using NotificationDomain.Entities;
using NotificationServices.DTOs;
using NotificationServices.Interfaces;

namespace NotificationServices.Services
{
    public class NotificationTypeService : INotificationTypeService
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;

        public NotificationTypeService(INotificationTypeRepository notificationTypeRepository)
        {
            _notificationTypeRepository = notificationTypeRepository;
        }
        public Task<NotificationType> CreateAsync(CreateNotificationTypeDto createNotificationTypeDto)
        {
            var notificationType = new NotificationType { Name = createNotificationTypeDto.Name, Description = createNotificationTypeDto.Description };

            _notificationTypeRepository.CreateAsync(notificationType);

            return Task.FromResult(notificationType);
        }
        public async Task UpdateAsync(UpdateNotificationTypeDto updateNotificationTypeDto)
        {
            NotificationType notificationType = await _notificationTypeRepository.GetByIdTypesAsync(updateNotificationTypeDto.Id);

            if(notificationType == null)
            {
                return;
            }
            else
            {
                await _notificationTypeRepository.UpdateAsync(notificationType);
            }
        }
        public Task DeleteAsync(int id)
        {
           return _notificationTypeRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<NotificationType>> GetAllAsync()
        {
            return _notificationTypeRepository.GetAllTypesAsync();
        }

        public Task<NotificationType> GetByIdAsync(int id)
        {
           return _notificationTypeRepository.GetByIdTypesAsync(id);
        }
    }
}
