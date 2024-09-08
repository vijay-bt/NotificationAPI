using Microsoft.EntityFrameworkCore;
using NotificationDomain.Entities;
using NotificationInfrastructure.Data;
using NotificationServices.Interfaces;

namespace NotificationInfrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationDbContext _context;

        public NotificationRepository(NotificationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Notification> GetAll()
        {
            return _context.Notifications.AsQueryable();
        }

        public async Task<Notification> GetByIdAsync(int id)
        {
            return await _context.Notifications.Include(n => n.NotificationType).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<Notification>> GetByUserIdAsync(int userId)
        {
            return await _context.Notifications.Where(n => n.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetByTypeAsync(int typeId)
        {
            return await _context.Notifications.Where(n => n.NotificationTypeId == typeId).ToListAsync();
        }

        public async Task SendAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notification notification)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }

   
    }
}
