using Microsoft.EntityFrameworkCore;
using NotificationDomain.Entities;
using NotificationInfrastructure.Data;
using NotificationInfrastructure.Repositories;
using NotificationServices.DTOs;
using NotificationServices.Services;
using NUnit.Framework;

namespace NotificationTests
{
    public class NotificationServiceTests
    {
        private NotificationDbContext _context;
        private NotificationRepository _notificationRepository;
        private NotificationService _notificationService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<NotificationDbContext>()
                .UseInMemoryDatabase(databaseName: "NotificationTestDb")
                .Options;

            _context = new NotificationDbContext(options);
            _notificationRepository = new NotificationRepository(_context);
            _notificationService = new NotificationService(_notificationRepository);
        }

        [Test]
        public async Task TestSendNotification()
        {
            var dto = new SendNotificationDto
            {
                UserId = 101,
                NotificationTypeId = 1,
                Channel = Channel.Email,
                Content = "Test Send Email"
            };

            await _notificationService.SendNotificationAsync(dto);

            var notifications = await _context.Notifications.ToListAsync();
            Assert.That(notifications.Count, Is.EqualTo(1));
            Assert.That(notifications[0].Content, Is.EqualTo("Test Send Email"));
        }
    }
}