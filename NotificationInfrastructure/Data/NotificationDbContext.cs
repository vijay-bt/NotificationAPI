using Microsoft.EntityFrameworkCore;
using NotificationDomain.Entities;

namespace NotificationInfrastructure.Data
{
    public class NotificationDbContext : DbContext
    {
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed initial NotificationType data
            modelBuilder.Entity<NotificationType>().HasData(
                new NotificationType { Id = 1, Name = "Promotional", Description = "Promotional Notifications" },
                new NotificationType { Id = 2, Name = "Transactional", Description = "Transactional Notifications" },
                new NotificationType { Id = 3, Name = "Alert", Description = "Alert Notifications" }
            );

            // Seed initial Notification data
            modelBuilder.Entity<Notification>().HasData(
                new Notification { Id = 1, UserId = 101, NotificationTypeId = 1, Content = "Welcome to our platform!", SentDate = DateTime.UtcNow, Status = "Sent" },
                new Notification { Id = 2, UserId = 102, NotificationTypeId = 2, Content = "Your transaction is complete", SentDate = DateTime.UtcNow, Status = "Sent" },
                new Notification { Id = 3, UserId = 103, NotificationTypeId = 3, Content = "Your account has a new alert", SentDate = DateTime.UtcNow, Status = "Sent" }
            );
        }
    }
}
