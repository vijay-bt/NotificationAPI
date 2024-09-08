using Microsoft.EntityFrameworkCore;
using NotificationDomain.Entities;
using NotificationInfrastructure.Data;
using NotificationServices.Interfaces;

namespace NotificationInfrastructure.Repositories
{
    public class NotificationTypeRepository : INotificationTypeRepository
    {
        private readonly NotificationDbContext _context;

        public NotificationTypeRepository(NotificationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(NotificationType notificationType)
        {
            await _context.NotificationTypes.AddAsync(notificationType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(NotificationType notificationType)
        {
            _context.NotificationTypes.Update(notificationType);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var notification = await _context.NotificationTypes.FindAsync(id);
            if (notification != null)
            {
                _context.NotificationTypes.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<NotificationType> GetByIdTypesAsync(int id)
        {
            return await _context.NotificationTypes.FindAsync(id);
        }
        public async Task<IEnumerable<NotificationType>> GetAllTypesAsync()
        {
            return await _context.NotificationTypes.ToListAsync();
        }
    }
}
