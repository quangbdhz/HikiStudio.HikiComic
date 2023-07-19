using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Artists;
using HikiComic.ViewModels.Authors;
using HikiComic.ViewModels.ComicDetails;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genres;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HikiComic.Application.ComicDetails
{
    public class ComicDetailService : IComicDetailService
    {
        private readonly HikiComicDbContext _context;

        public ComicDetailService(HikiComicDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicId(int comicId)
        {
            return await GetDetaiComicViewModel(1, null, comicId, null);
        }

        public async Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicId(Guid userId, int comicId)
        {
            return await GetDetaiComicViewModel(1, null, comicId, userId);
        }

        public async Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicSEOAlias(string comicSEOAlias, bool isManagement = false)
        {
            comicSEOAlias = WebUtility.UrlDecode(comicSEOAlias);

            return await GetDetaiComicViewModel(2, comicSEOAlias, null, null, isManagement);
        }

        public async Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicSEOAliasWithUser(Guid userId, string comicSEOAlias)
        {
            comicSEOAlias = WebUtility.UrlDecode(comicSEOAlias);

            return await GetDetaiComicViewModel(2, comicSEOAlias, null, userId);
        }

        public async Task<Comic?> GetComic(int comicId, bool isManagement)
        {
            if (!isManagement)
            {
                return await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == comicId && x.IsDeleted == false);
            }
            else
            {
                return await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == comicId);
            }
        }

        public async Task<ComicDetailViewModel?> GetComicDetail(int option, string? comicSEOAlias, int? comicId)
        {
            if (option == 1)
            {
                var query = from cd in _context.ComicDetails
                            where cd.ComicId == comicId
                            join cb in _context.Users on cd.CreatedBy equals cb.Id into createdByGroup
                            from cb in createdByGroup.DefaultIfEmpty()
                            join ub in _context.Users on cd.UpdatedBy equals ub.Id into updatedByGroup
                            from ub in updatedByGroup.DefaultIfEmpty()
                            select new { cd, cb, ub };

                var comicDetail = await query.Select(x => new ComicDetailViewModel()
                {
                    ComicDetailId = x.cd.ComicDetailId,
                    ComicId = x.cd.ComicId,
                    Status = ((ComicStatusEnum)x.cd.StatusId).ToString(),
                    Summary = x.cd.Summary,
                    ComicSEOAlias = x.cd.ComicSEOAlias,
                    ComicSEOTitle = x.cd.ComicSEOTitle,
                    ComicSEOSummary = x.cd.ComicSEOSummary,
                    DateCreated = x.cd.DateCreated,
                    UserNameCreatedBy = x.cb.UserName,
                    DateUpdated = x.cd.DateUpdated,
                    UserNameUpdatedBy = x.ub.UserName
                }).FirstOrDefaultAsync();

                return comicDetail;
            }
            else
            {
                var query = from cd in _context.ComicDetails
                            where cd.ComicSEOAlias == comicSEOAlias
                            join cb in _context.Users on cd.CreatedBy equals cb.Id into createdByGroup
                            from cb in createdByGroup.DefaultIfEmpty()
                            join ub in _context.Users on cd.UpdatedBy equals ub.Id into updatedByGroup
                            from ub in updatedByGroup.DefaultIfEmpty()
                            select new { cd, cb, ub };

                var comicDetail = await query.Select(x => new ComicDetailViewModel()
                {
                    ComicDetailId = x.cd.ComicDetailId,
                    ComicId = x.cd.ComicId,
                    Status = ((ComicStatusEnum)x.cd.StatusId).ToString(),
                    Summary = x.cd.Summary,
                    ComicSEOAlias = x.cd.ComicSEOAlias,
                    ComicSEOTitle = x.cd.ComicSEOTitle,
                    ComicSEOSummary = x.cd.ComicSEOSummary,
                    DateCreated = x.cd.DateCreated,
                    UserNameCreatedBy = x.cb.UserName,
                    DateUpdated = x.cd.DateUpdated,
                    UserNameUpdatedBy = x.ub.UserName
                }).FirstOrDefaultAsync();

                return comicDetail;
            }
        }

        public async Task<ApiResult<ComicDetailViewModel>> GetDetaiComicViewModel(int option, string? comicSEOAlias, int? comicId, Guid? userId, bool isManagement = false)
        {
            var comicDetail = await GetComicDetail(option, comicSEOAlias, comicId);
            if (comicDetail == null)
                return new ApiErrorResult<ComicDetailViewModel>(MessageConstants.ObjectNotFound("Comic Detail"));

            var comic = await GetComic(comicDetail.ComicId, isManagement);
            if (comic == null)
                return new ApiErrorResult<ComicDetailViewModel>(MessageConstants.ObjectNotFound("Comic"));

            var creatorOfComicHighRole = from u in _context.Users
                                         join ur in _context.UserRoles on u.Id equals ur.UserId
                                         join r in _context.Roles on ur.RoleId equals r.Id
                                         where (r.Name == SystemConstants.AppSettings.AdminRole || r.Name == SystemConstants.AppSettings.TeamMembersRole) && u.Id == comic.CreatedBy
                                         select u;

            //is high role: admin & team members
            string creatorName = "";
            if (await creatorOfComicHighRole.CountAsync() > 0)
            {
                creatorName = "HikiComic System";
            }
            else
            {
                var queryCreator = from u in _context.Users
                                   join a in _context.Accounts on u.Id equals a.AppUserId
                                   where u.Id == comic.CreatedBy
                                   select new { u, a };

                var creator = await queryCreator.Select(x => new
                {
                    Nickname = x.a.Nickname,
                    Email = x.u.Email,
                    UserName = x.u.UserName
                }).FirstOrDefaultAsync();

                if (creator is null)
                {
                    creatorName = "Updating";
                }
                else
                {
                    creatorName = String.IsNullOrEmpty(creator.Nickname) ? creator.UserName : creator.Nickname;
                }
            }

            var queryArtists = from a in _context.Artists
                               join aidc in _context.ArtistInComicDetails on a.ArtistId equals aidc.ArtistId
                               where aidc.ComicDetailId == comicDetail.ComicDetailId && a.IsDeleted == false
                               select a;

            var artists = await queryArtists.Select(x => new ArtistViewModel()
            {
                ArtistId = x.ArtistId,
                ArtistName = x.ArtistName,
                Alternative = x.Alternative,
                ArtistSEOAlias = x.ArtistSEOAlias,
                DateCreated = x.DateCreated,
                IsDeleted = x.IsDeleted
            }).ToListAsync();

            var queryAuthors = from a in _context.Authors
                               join aidc in _context.AuthorInComicDetails on a.AuthorId equals aidc.AuthorId
                               where aidc.ComicDetailId == comicDetail.ComicDetailId && a.IsDeleted == false
                               select a;

            var authors = await queryAuthors.Select(x => new AuthorViewModel()
            {
                AuthorId = x.AuthorId,
                AuthorName = x.AuthorName,
                Alternative = x.Alternative,
                AuthorSEOAlias = x.AuthorSEOAlias,
                DateCreated = x.DateCreated,
                IsDeleted = x.IsDeleted
            }).ToListAsync();

            var queryGenre = from g in _context.Genres
                             join gd in _context.GenreDetails on g.GenreId equals gd.GenreId
                             join gicd in _context.GenreInComicDetails on g.GenreId equals gicd.GenreId
                             where gicd.ComicDetailId == comicDetail.ComicDetailId
                             select new { g, gd };

            var genres = await queryGenre.Select(x => new GenreViewModel()
            {
                GenreId = x.g.GenreId,
                GenreName = x.gd.GenreName,
                GenreSEOAlias = x.gd.GenreSEOAlias,
                GenreParentId = x.g.GenreParentId
            }).ToListAsync();

            var comicDetailViewModel = new ComicDetailViewModel()
            {
                ComicId = comic.ComicId,
                ComicName = comic.ComicName,
                Alternative = comic.Alternative,
                ViewCount = comic.ViewCount,
                ComicCoverImageURL = comic.ComicCoverImageURL,
                NewChapterId = comic.NewChapterId,
                Rating = comic.Rating,
                CountRating = comic.CountRating,
                CountFollow = comic.CountFollow,
                Summary = comicDetail.Summary,
                ComicSEOSummary = comicDetail.ComicSEOSummary,
                ComicSEOTitle = comicDetail.ComicSEOTitle,
                ComicSEOAlias = comicDetail.ComicSEOAlias,
                IsDeleted = comic.IsDeleted,
                Artists = artists,
                Authors = authors,
                Genres = genres,
                Status = comicDetail.Status,
                CreatorName = creatorName,
                DateCreated = comic.DateCreated,
                UserNameCreatedBy = comicDetail.UserNameCreatedBy,
                DateUpdated = comicDetail.DateUpdated,
                UserNameUpdatedBy = comicDetail.UserNameUpdatedBy,
            };

            if (userId != null)
            {
                var userFollowComic = await _context.UserComicFollowings.FirstOrDefaultAsync(x => x.AppUserId == userId && x.ComicId == comicDetail.ComicId);
                if (userFollowComic != null)
                {
                    comicDetailViewModel.IsFollow = true;
                }

            }

            return new ApiSuccessResult<ComicDetailViewModel>() { ResultObj = comicDetailViewModel };
        }

        public async Task<ApiResult<bool>> UpdateStatusUserFollowComic(Guid userId, int comicId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            var comic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == comicId);
            if (comic == null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Coimic Strip") };

            var userFollowComic = await _context.UserComicFollowings.FirstOrDefaultAsync(x => x.ComicId == comicId && x.AppUserId == userId);
            if (userFollowComic == null)
            {
                comic.CountFollow++;
                UserComicFollowing listOfComicsUsersFollow = new UserComicFollowing()
                {
                    AppUserId = userId,
                    ComicId = comicId,
                    DateFollow = DateTime.Now
                };
                await _context.UserComicFollowings.AddAsync(listOfComicsUsersFollow);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.ComicFollowingSuccess };
            }
            else
            {
                _context.UserComicFollowings.Remove(userFollowComic);
                comic.CountFollow--;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.UnfollowComicSuccess };
            }
        }

        //public async Task<ApiResult<bool>> UpdateSummaryComicDetail(UpdateSummaryComicDetailRequest request)
        //{
        //    var checkComicDetailExits = await _context.ComicDetails.FirstOrDefaultAsync((x) => x.ComicDetailId == request.ComicDetailId);

        //    if (checkComicDetailExits == null)
        //        return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("ComicDetail"));

        //    checkComicDetailExits.Summary = request.Summary.Replace("NetTruyen", "HikiComic");
        //    await _context.SaveChangesAsync();
        //    return new ApiSuccessResult<bool>() { Message = MessageConstants.UpdateSuccess("Summary of ComicDetail") };
        //}
    }
}
