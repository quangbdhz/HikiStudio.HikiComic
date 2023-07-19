using HikiComic.Application.Firebases;
using HikiComic.Application.Notifications;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        private readonly IFirebaseCloudMessagingService _firebaseCloudMessagingService;

        public NotificationsController(INotificationService notificationService, IFirebaseCloudMessagingService firebaseCloudMessagingService)
        {
            _notificationService = notificationService;
            _firebaseCloudMessagingService = firebaseCloudMessagingService;
        }

        [HttpPost("paging-management")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(GetPagingManagement), nameof(PagingRequest)) });

            var notifications = await _notificationService.GetPagingManagement(request);

            return Ok(notifications);
        }

        [HttpGet("paging-notification-for-creator")]
        [Authorize(Policy = SystemConstants.AppSettings.CreatorPolicy)]
        public async Task<IActionResult> GetPagingNofiticationForCreator([FromQuery] PagingRequestBase request)
        {
            var result = await _notificationService.GetPagingNofiticationForCreator(request);

            return Ok(result);
        }

        [HttpGet("paging-notification-for-admin-and-team-members")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetPagingNofiticationForAdminAndTeamMembers([FromQuery] PagingRequestBase request)
        {
            var result = await _notificationService.GetPagingNofiticationForAdminAndTeamMembers(request);

            return Ok(result);
        }

        /// <summary>
        /// Feature: Retrieves a paged list of notifications for a specific user.
        /// </summary>
        /// <param name="request">The paging request object.</param>
        /// <returns>An IActionResult representing the HTTP response containing the paged list of notification view models.</returns>
        [HttpPost("paging-by-user")]
        public async Task<IActionResult> GetPagingNotificationsByUserId([FromBody] PagingRequestBase request)
        {
            var data = await _notificationService.GetPagingNotificationsByUserId(request);

            return Ok(data);
        }

        [HttpGet("get-notification-by-notification-id/{notificationId}")]
        public async Task<IActionResult> GetNotificationByNotificationId(int notificationId)
        {
            var result = await _notificationService.GetNotificationByNotificationId(notificationId);

            return Ok(result);
        }

        /// <summary>
        /// Feature: Marks all notifications for the current user as read.
        /// </summary>
        /// <returns>An IActionResult representing the HTTP response indicating whether the operation was successful.</returns>
        [HttpPost("user-mark-all-notifications")]
        public async Task<IActionResult> UserMarkAllNotificationsAsRead()
        {
            var result = await _notificationService.UserMarkAllNotificationsAsRead();

            return Ok(result);
        }

        /// <summary>
        /// Feature: Deletes all notifications for the current user.
        /// </summary>
        /// <returns>An IActionResult representing the HTTP response indicating whether the operation was successful.</returns>
        [HttpDelete("user-delete-all-notifications")]
        public async Task<IActionResult> UserDeleteAllNotifications()
        {
            var result = await _notificationService.UserDeleteAllNotifications();

            return Ok(result);
        }

        /// <summary>
        /// Feature: Marks a notification as read.
        /// </summary>
        /// <param name="notificationId">The ID of the notification to mark as read.</param>
        /// <returns>An IActionResult representing the HTTP response indicating whether the operation was successful.</returns>
        [HttpPatch("user-read-notification")]
        public async Task<IActionResult> UserIsReadNotification([FromBody] int notificationId)
        {
            if (notificationId <= 0)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("NotificationID") });

            var result = await _notificationService.UserIsReadNotification(notificationId);

            return Ok(result);
        }

        /// <summary>
        /// Feature: Creates a system notification based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create-notification-system")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> CreateNotificationSystem(CreateNotificationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateNotificationSystem), nameof(CreateNotificationRequest)) });

            var result = await _notificationService.CreateNotification(request, NotificationTypeEnum.System);

            return Ok(result);
        }

        /// <summary>
        /// Feauture: Added feature in comments (create comment)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create-notification-reply-comment")]
        [Authorize]
        public IActionResult CreateNotificationReplyComment(CreateNotificationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateNotificationReplyComment), nameof(CreateNotificationRequest)) });

            //var result = await _notificationService.CreateNotification(request, NotificationTypeEnum.ReplyComment, userId);

            //return Ok(result);

            return Ok();
        }

        /// <summary>
        /// Feature: Updates a notification with the specified ID.
        /// </summary>
        /// <param name="request">The request object containing the updated notification data.</param>
        /// <param name="notificationId">The ID of the notification to update.</param>
        /// <returns></returns>
        [HttpPut("update/{notificationId}")]
        [Authorize]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationRequest request, int notificationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(UpdateNotification), nameof(UpdateNotificationRequest)) });

            var result = await _notificationService.UpdateNotification(request, notificationId);

            return Ok(result);
        }

        /// <summary>
        /// Feature: Deletes a notification with the specified ID.
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        [HttpDelete("delete/{notificationId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            var result = await _notificationService.DeleteNotification(notificationId);

            return Ok(result);
        }

        /// <summary>
        /// Feature: Deletes multiple notifications based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("delete-multiple")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteNotifications([FromBody] DeleteNotificationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(DeleteNotificationRequest)) });

            var result = await _notificationService.DeleteNotifications(request);

            return Ok(result);
        }

        /// <summary>
        /// Feature: Restores a deleted system notification.
        /// </summary>
        /// <param name="notificationId">The ID of the notification to restore.</param>
        /// <returns>An IActionResult representing the HTTP response indicating whether the operation was successful.</returns>
        [HttpPost("restore")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> RestoreNotification([FromBody] int notificationId)
        {
            if (notificationId <= 0)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("NotificationID") });

            var result = await _notificationService.RestoreNotification(notificationId);

            return Ok(result);
        }
    }
}
