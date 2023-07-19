using AutoMapper;
using AutoMapper.QueryableExtensions;
using HikiComic.Application.Notifications;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Comments;
using HikiComic.ViewModels.Comments.CommentDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genres;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;
using Microsoft.EntityFrameworkCore;

using System.Linq.Dynamic.Core;
using System.Text;

namespace HikiComic.Application.Comments
{
    public class CommentService : ICommentService
    {
        private readonly HikiComicDbContext _context;

        private readonly INotificationService _notificationService;

        public CommentService(HikiComicDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<ViewModels.Common.PagedResult<CommentViewModel>> GetPaging(CommentPagingRequest request)
        {
            var pagedResult = new ViewModels.Common.PagedResult<CommentViewModel>()
            {
                PageSize = request.PageSize,
                PageIndex = request.PageIndex
            };

            var query = _context.Comments
                .Include(c => c.ChildComments)
                    .ThenInclude(cc => cc.AppUser)
                .Include(c => c.AppUser)
                    .ThenInclude(c => c.Account)
                .Where(c => c.ComicId == request.ComicId && c.ChapterId == request.ChapterId && c.ParentCommentId == null && c.IsDeleted == false);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentViewModel>()
                    .ForMember(dest => dest.StringDateCreated, opt => opt.MapFrom(src => src.DateCreated.ToString("hh:mm tt dd/MM/yyyy")))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => !String.IsNullOrEmpty(src.AppUser.Account.Nickname) ? src.AppUser.Account.Nickname : src.AppUser.UserName))
                    .ForMember(dest => dest.URLImageUser, opt => opt.MapFrom(src => src.AppUser.UserImageURL != null && src.AppUser.UserImageURL.Contains("http") ? src.AppUser.UserImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + src.AppUser.UserImageURL))
                    .ForMember(dest => dest.UserIsVerified, opt => opt.MapFrom(src => src.AppUser.PhoneNumberConfirmed && src.AppUser.EmailConfirmed))
                    .ForMember(dest => dest.ChildComments, opt => opt.MapFrom(src => src.ChildComments.Where(cc => !cc.IsDeleted)));
            });

            var mapper = config.CreateMapper();

            var commentsOnPage = await query
                .OrderByDescending(c => c.DateCreated)
                .Skip((pagedResult.PageIndex - 1) * pagedResult.PageSize)
                .Take(pagedResult.PageSize)
                .ProjectTo<CommentViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            pagedResult.Items = commentsOnPage;
            pagedResult.TotalRecords = await query.CountAsync();

            return pagedResult;
        }

        public PagingResult<CommentViewModel> GetPagingManagement(CommentPagingManagementRequest request)
        {
            //var pagedResult = new PagedResult<CommentViewModel>()
            //{
            //    PageSize = request.PageSize,
            //    PageIndex = request.PageIndex
            //};

            //var query = _context.Comments
            //    .Include(c => c.ChildComments)
            //    .Include(c => c.AppUser)
            //    .Where(c => c.ComicId == request.ComicId && c.ChapterId == request.ChapterId && c.ParentCommentId == null);


            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Comment, CommentViewModel>()
            //        .ForMember(dest => dest.StringDateCreated, opt => opt.MapFrom(src => src.DateCreated.ToString("hh:mm tt dd/MM/yyyy")))
            //        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName))
            //        .ForMember(dest => dest.URLImageUser, opt => opt.MapFrom(src => src.AppUser.UserImageURL));
            //});

            //var mapper = config.CreateMapper();

            //var commentsOnPage = await query
            //    .OrderByDescending(c => c.DateCreated)
            //    .Skip((pagedResult.PageIndex - 1) * pagedResult.PageSize)
            //    .Take(pagedResult.PageSize)
            //    .ProjectTo<CommentViewModel>(mapper.ConfigurationProvider)
            //    .ToListAsync();

            //pagedResult.TotalRecords = await query.CountAsync();
            //pagedResult.Items = commentsOnPage;

            //return pagedResult;

            return new PagingResult<CommentViewModel>();
        }

        public async Task<PagingResult<UserCommentViewModel>> GetPagingOfUser(Guid userId, PagingRequest request)
        {
            var query = from c in _context.Comments
                        join cs in _context.Comics on c.ComicId equals cs.ComicId
                        join cd in _context.ComicDetails on cs.ComicId equals cd.ComicId
                        where c.AppUserId == userId
                        orderby c.DateCreated descending
                        select new { c, cs, cd };

            var commentViewModels = await query.OrderByDescending(x => x.c.CommentId).Select(x => new UserCommentViewModel()
            {
                CommentId = x.c.CommentId,
                ComicId = x.c.ComicId,
                ChapterId = x.c.ChapterId,
                ComicName = x.cs.ComicName,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                CommentContent = x.c.CommentContent,
                DateCreated = x.c.DateCreated,
                Dislike = x.c.Dislike,
                Like = x.c.Like,
                IsDeleted = x.c.IsDeleted
            }).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                commentViewModels = await query.Select(x => new UserCommentViewModel()
                {
                    CommentId = x.c.CommentId,
                    ComicId = x.c.ComicId,
                    ChapterId = x.c.ChapterId,
                    ComicName = x.cs.ComicName,
                    ComicSEOAlias = x.cd.ComicSEOAlias,
                    CommentContent = x.c.CommentContent,
                    DateCreated = x.c.DateCreated,
                    Dislike = x.c.Dislike,
                    Like = x.c.Like,
                    IsDeleted = x.c.IsDeleted
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                commentViewModels = commentViewModels.Where(x => x.CommentContent.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = commentViewModels.Count();
            var data = commentViewModels.Skip(request.Skip).Take(request.PageSize).ToList();


            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<UserCommentViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        public async Task<ApiResult<UserCommentViewModel>> GetCommentByCommentId(int commentId)
        {
            var query = from c in _context.Comments
                        join cs in _context.Comics on c.ComicId equals cs.ComicId
                        join cd in _context.ComicDetails on cs.ComicId equals cd.ComicId
                        where c.CommentId == commentId
                        select new { c, cs, cd };

            var comment = await query.Select(x => new UserCommentViewModel()
            {
                CommentId = x.c.CommentId,
                ComicId = x.c.ComicId,
                ChapterId = x.c.ChapterId,
                ComicName = x.cs.ComicName,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                CommentContent = x.c.CommentContent,
                DateCreated = x.c.DateCreated,
                Dislike = x.c.Dislike,
                Like = x.c.Like,
                IsDeleted = !x.c.IsDeleted
            }).FirstOrDefaultAsync();

            if (comment is null)
                return new ApiSuccessResult<UserCommentViewModel>() { Message = MessageConstants.ObjectNotFound("Comment") };

            return new ApiSuccessResult<UserCommentViewModel>() { ResultObj = comment };

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<CommentViewModel>> CreateComment(Guid userId, CreateCommentRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user is null)
                return new ApiErrorResult<CommentViewModel>(MessageConstants.ObjectNotFound("User"));

            if (user.LockoutEnabled)
                return new ApiErrorResult<CommentViewModel>() { Message = MessageConstants.AccountLocked };

            if (user.IsDeleted)
                return new ApiErrorResult<CommentViewModel>() { Message = MessageConstants.AccountDeleted };

            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == user.Id);
            if (account is null)
                return new ApiErrorResult<CommentViewModel>(MessageConstants.ObjectNotFound("Account"));

            var comment = new Comment()
            {
                AppUserId = userId,
                ComicId = request.ComicId,
                ChapterId = request.ChapterId,
                ParentCommentId = request.ParentCommentId,
                Dislike = 0,
                Like = 0,
                CommentContent = request.CommentContent,
                IsDeleted = false,
                DateCreated = DateTime.Now
            };

            if (request.ParentCommentId != null)
            {
                var parentComment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == request.ParentCommentId);

                if (parentComment == null)
                    return new ApiErrorResult<CommentViewModel>() { Message = MessageConstants.ObjectNotFound("ParentComment") };

                if (parentComment.ParentCommentId != null)
                    return new ApiErrorResult<CommentViewModel>() { Message = "ParentCommentId must be the Id of a ParentComment" };

                var userParentComment = await _context.Users.FirstOrDefaultAsync(x => x.Id == parentComment.AppUserId);

                if (userParentComment is null)
                    return new ApiErrorResult<CommentViewModel>() { Message = MessageConstants.ObjectNotFound("User Parent Comment") };

                // AppUserId -> Id of user receives notification
                // CreateAt -> Id of user send comment
                var createNotificationRequest = new CreateNotificationRequest()
                {
                    AppUserId = parentComment.AppUserId,
                    CreatedBy = user.Id,
                    Actions = null,
                    ComicId = request.ComicId,
                    ImageURL = user.UserImageURL,
                    IsRead = false,
                    NotificationPriority = NotificationPriorityEnum.Medium,
                    Title = user.UserName + " replied to your comment.",
                    Message = request.CommentContent.Length > 20 ? request.CommentContent.Substring(0, 19) + "..." : request.CommentContent
                };

                var resultCreateNotification = await _notificationService.CreateNotification(createNotificationRequest, NotificationTypeEnum.ReplyComment);

                if (!resultCreateNotification.IsSuccessed)
                    return new ApiErrorResult<CommentViewModel>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(CreateComment), "Create Notification Reply Comment") };
            }

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<CommentViewModel>()
            {
                ResultObj = new CommentViewModel()
                {
                    CommentContent = comment.CommentContent,
                    DateCreated = comment.DateCreated,
                    Dislike = comment.Dislike,
                    Like = comment.Like,
                    ComicId = comment.ComicId,
                    ChapterId = comment.ChapterId,
                    CommentId = comment.CommentId,
                    ParentCommentId = comment.ParentCommentId,
                    AppUserId = comment.AppUserId,
                    UserName = !String.IsNullOrEmpty(account.Nickname) ? account.Nickname : user.UserName,
                    URLImageUser = user.UserImageURL != null && user.UserImageURL.Contains("http") ? user.UserImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + user.UserImageURL
                },
                Message = MessageConstants.CreateSuccess("Comment")
            };
        }

        public async Task<ApiResult<int>> UserDeleteComment(Guid userId, int commentId)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == commentId);

            if (comment is null)
                return new ApiErrorResult<int>() { Message = MessageConstants.ObjectNotFound("Comment") };

            if (comment.AppUserId != userId)
                return new ApiErrorResult<int>() { Message = "You can only delete your own comments and are not allowed to delete others' comments" };

            comment.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>() { Message = MessageConstants.DeleteSuccess("Comment"), ResultObj = commentId };
        }

        public async Task<ApiResult<bool>> DeleteComment(int commentId)
        {
            var checkCommentAlreadyExists = await _context.Comments.FirstOrDefaultAsync((x) => x.CommentId == commentId);

            if (checkCommentAlreadyExists is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Comment With Id: " + commentId));

            checkCommentAlreadyExists.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess("Comment With Id " + commentId) };
        }

        public async Task<ApiResult<bool>> DeleteComments(DeleteCommentsRequest request)
        {
            var validCommentIds = request.CommentIds.Where(id => id > 0).ToList();

            var existingComments = await _context.Comments
                .Where(x => validCommentIds.Contains(x.CommentId))
                .ToListAsync();

            var errorMessageBuilder = new StringBuilder();

            foreach (var comment in existingComments)
            {
                if (comment.IsDeleted == true)
                {
                    errorMessageBuilder.AppendLine("Comment with Id: " + comment.CommentId + " deleted.");
                }
                else
                {
                    comment.IsDeleted = true;
                }
            }

            if (errorMessageBuilder.Length > 0)
            {
                var errorMessage = errorMessageBuilder.ToString().Trim();
                return new ApiErrorResult<bool>(errorMessage);
            }
            else
            {
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess(nameof(Comment)) };
            }
        }


        public async Task<ApiResult<bool>> RestoreDeletedComment(int commentId)
        {
            var checkCommentAlreadyExists = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == commentId);
            if (checkCommentAlreadyExists is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Comment"));

            if (!checkCommentAlreadyExists.IsDeleted)
                return new ApiErrorResult<bool>() { Message = MessageConstants.CurrentObjectDeleted("Comment") };

            checkCommentAlreadyExists.IsDeleted = false;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>(MessageConstants.RestoreObjectSuccess("Comment"));
        }



        //public async Task<ApiResult<int>> AdminDeleteComment(int commentId)
        //{
        //    var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == commentId);

        //    if (comment is null)
        //        return new ApiErrorResult<int>() { Message = MessageConstants.ObjectNotFound("Comment") };

        //    _context.Comments.Remove(comment);
        //    await _context.SaveChangesAsync();

        //    return new ApiSuccessResult<int>() { Message = MessageConstants.DeleteSuccess("Comment") };
        //}

    }
}