High-Level Design:

Entities:

1.	NotificationType
o	Id (GUID)
o	Name (e.g., Promotional, Transactional, Alert)
o	Description (optional text)

3.	Notification
o	Id (GUID)
o	UserId (GUID or int, referencing the user to receive the notification)
o	NotificationTypeId (GUID, foreign key to NotificationType)
o	Channel (enum: Email, SMS, PushNotification)
o	Content (text of the notification)
o	SentDate (timestamp)
o	Status (sent, failed, pending, etc.)
4.	Channel (Enum):
o	Email
o	SMS
o	PushNotification

API Functionalities:
1.	Notification Type Endpoints:
o	Create a notification type
o	Update a notification type
o	Delete a notification type
o	Retrieve details of a specific notification type by ID
o	List all notification types

3.	Notification Endpoints:
o	Send a notification to a user (specify channel)
o	Retrieve the status of a sent notification
o	List all notifications sent within a specific time range, optionally filtered by user or notification type

Architecture

Implemented using Clean Architecture ensures separation of concerns by splitting the application into distinct layers:
1.	Domain Layer (Entities, Enums, Interfaces, Business Logic)
2.	Infrastructure Layer (EF Core Repositories, External Services)
3.	Service (Application) Layer (Use cases, DTOs, Services)
4.	API Layer (Controllers)

Detailed Design:
1. Domain Layer (Entities and Business Logic):
Define entities, enums, and interfaces that will be used across the project.

Entities:
 	NotificationType
 	Notification
 	enum Channel
 	enum Status
  
2. Infrastructure Layer (EF Core + In-Memory Database):

Use Entity Framework Core to manage data access.

DbContext Setup:
 	NotificationDbContext
  Repository Implementation:
 	NotificationTypeRepository
 	NotificationRepository

4. Application Layer (Services, DTOs, and Business Logic):
In this layer, we manage the business logic, including sending notifications, checking statuses, and filtering by user or date range.

DTOs:
 	CreateNotificationTypeDto
 	NotificationStatusDto
 	SendNotificationDto
 	UpdateNotificationTypeDto
  
Interfaces:
 	INotificationTypeRepository
 	INotificationRepository
 	INotificationTypeService
 	INotificationService
  
Services:
 	NotificationService
 	NotificationTypeService
  
5. API Layer (Controllers):

Implement the RESTful API using ASP.NET Core Web API controllers.

	NotificationTypeController
	NotificationController

Unit Test:

Implemented TDD using NUnit framework, added one test for SendNotifcation for Service Test.

	NotificationServiceTests
