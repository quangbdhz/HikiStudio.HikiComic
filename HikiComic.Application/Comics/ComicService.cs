using HikiComic.Application.Common;
using HikiComic.Application.Notifications;
using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Comics.ComicDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Text;

namespace HikiComic.Application.Comics
{
    public class ComicService : IComicService
    {
        private readonly HikiComicDbContext _context;

        private readonly ICommonService _commonService;

        private readonly IUserContextService _userContextService;

        private readonly INotificationService _notificationService;

        public ComicService(HikiComicDbContext context, ICommonService commonService, IUserContextService userContextService, INotificationService notificationService)
        {
            _context = context;
            _commonService = commonService;
            _userContextService = userContextService;
            _notificationService = notificationService;
        }

        #region get comic
        public async Task<ViewModels.Common.PagedResult<ComicViewModel>> GetComicByGenrePaging(ComicByGenrePagingRequest request)
        {
            if (request.GenreId != null && request.GenreId != 0)
            {
                var query = from c in _context.Comics
                            join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                            join s in _context.Statuses on cd.StatusId equals s.StatusId
                            join cicd in _context.GenreInComicDetails on cd.ComicDetailId equals cicd.ComicDetailId
                            orderby c.ComicId descending
                            where c.IsDeleted == false && c.ApprovalStatus == ApprovalStatusEnum.Approved
                            select new { c, cd, cicd, s };

                query = query.Where(p => p.cicd.GenreId == request.GenreId);

                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.c.ComicName.Contains(request.Keyword));

                int totalRow = await query.CountAsync();

                var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                  .Select(x => new ComicViewModel()
                  {
                      ComicId = x.c.ComicId,
                      ComicName = x.c.ComicName,
                      DateCreated = x.c.DateCreated,
                      Alternative = x.c.Alternative,
                      ViewCount = x.c.ViewCount,
                      ComicCoverImageURL = x.c.ComicCoverImageURL,
                      NewChapterId = x.c.NewChapterId,
                      ComicSEOAlias = x.cd.ComicSEOAlias,
                      Rating = x.c.Rating,
                      IsDeleted = x.c.IsDeleted,
                      Status = x.s.StatusName
                  }).ToListAsync();

                var pagedResult = new ViewModels.Common.PagedResult<ComicViewModel>()
                {
                    TotalRecords = totalRow,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Items = data
                };
                return pagedResult;
            }
            else
            {
                var result = await GetComicByComicName(request.Keyword, request.PageIndex, request.PageSize);
                return result;
            }
        }

        public async Task<ViewModels.Common.PagedResult<ComicViewModel>> GetComicByAuthorPaging(ComicByAuthorPagingRequest request)
        {
            if (request.AuthorId != null && request.AuthorId != 0)
            {
                var query = from c in _context.Comics
                            join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                            join s in _context.Statuses on cd.StatusId equals s.StatusId
                            join aicd in _context.AuthorInComicDetails on cd.ComicDetailId equals aicd.ComicDetailId
                            orderby c.ComicId descending
                            where c.IsDeleted == false && c.ApprovalStatus == ApprovalStatusEnum.Approved
                            select new { c, cd, aicd, s };

                query = query.Where(p => p.aicd.AuthorId == request.AuthorId);

                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.c.ComicName.Contains(request.Keyword));

                int totalRow = await query.CountAsync();

                var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                  .Select(x => new ComicViewModel()
                  {
                      ComicId = x.c.ComicId,
                      ComicName = x.c.ComicName,
                      DateCreated = x.c.DateCreated,
                      Alternative = x.c.Alternative,
                      ViewCount = x.c.ViewCount,
                      ComicCoverImageURL = x.c.ComicCoverImageURL,
                      NewChapterId = x.c.NewChapterId,
                      ComicSEOAlias = x.cd.ComicSEOAlias,
                      Rating = x.c.Rating,
                      IsDeleted = x.c.IsDeleted,
                      Status = x.s.StatusName
                  }).ToListAsync();

                var pagedResult = new ViewModels.Common.PagedResult<ComicViewModel>()
                {
                    TotalRecords = totalRow,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Items = data
                };
                return pagedResult;
            }
            else
            {
                var result = await GetComicByComicName(request.Keyword, request.PageIndex, request.PageSize);
                return result;
            }
        }

        public async Task<ViewModels.Common.PagedResult<ComicViewModel>> GetComicByArtistPaging(ComicByArtistPagingRequest request)
        {
            if (request.ArtistId != null && request.ArtistId != 0)
            {
                var query = from c in _context.Comics
                            join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                            join s in _context.Statuses on cd.StatusId equals s.StatusId
                            join aicd in _context.ArtistInComicDetails on cd.ComicDetailId equals aicd.ComicDetailId
                            orderby c.ComicId descending
                            where c.IsDeleted == false && c.ApprovalStatus == ApprovalStatusEnum.Approved
                            select new { c, cd, aicd, s };

                query = query.Where(p => p.aicd.ArtistId == request.ArtistId);

                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.c.ComicName.Contains(request.Keyword));

                int totalRow = await query.CountAsync();

                var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                  .Select(x => new ComicViewModel()
                  {
                      ComicId = x.c.ComicId,
                      ComicName = x.c.ComicName,
                      DateCreated = x.c.DateCreated,
                      Alternative = x.c.Alternative,
                      ViewCount = x.c.ViewCount,
                      ComicCoverImageURL = x.c.ComicCoverImageURL,
                      NewChapterId = x.c.NewChapterId,
                      ComicSEOAlias = x.cd.ComicSEOAlias,
                      Rating = x.c.Rating,
                      IsDeleted = x.c.IsDeleted,
                      Status = x.s.StatusName
                  }).ToListAsync();

                var pagedResult = new ViewModels.Common.PagedResult<ComicViewModel>()
                {
                    TotalRecords = totalRow,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Items = data
                };
                return pagedResult;
            }
            else
            {
                var result = await GetComicByComicName(request.Keyword, request.PageIndex, request.PageSize);
                return result;
            }
        }

        public async Task<ViewModels.Common.PagedResult<ComicViewModel>> GetComicByStatusPaging(ComicByStatusPagingRequest request)
        {
            if (request.StatusId != null && request.StatusId != 0)
            {
                var query = from c in _context.Comics
                            join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                            join s in _context.Statuses on cd.StatusId equals s.StatusId
                            join aicd in _context.ArtistInComicDetails on cd.ComicDetailId equals aicd.ComicDetailId
                            orderby c.ComicId descending
                            where c.IsDeleted == false && c.ApprovalStatus == ApprovalStatusEnum.Approved
                            select new { c, cd, aicd, s };

                query = query.Where(p => p.s.StatusId == request.StatusId);

                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.c.ComicName.Contains(request.Keyword));

                int totalRow = await query.CountAsync();

                var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                  .Select(x => new ComicViewModel()
                  {
                      ComicId = x.c.ComicId,
                      ComicName = x.c.ComicName,
                      DateCreated = x.c.DateCreated,
                      Alternative = x.c.Alternative,
                      ViewCount = x.c.ViewCount,
                      ComicCoverImageURL = x.c.ComicCoverImageURL,
                      NewChapterId = x.c.NewChapterId,
                      ComicSEOAlias = x.cd.ComicSEOAlias,
                      Rating = x.c.Rating,
                      IsDeleted = x.c.IsDeleted,
                      Status = x.s.StatusName
                  }).ToListAsync();

                var pagedResult = new ViewModels.Common.PagedResult<ComicViewModel>()
                {
                    TotalRecords = totalRow,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Items = data
                };
                return pagedResult;
            }
            else
            {
                var result = await GetComicByComicName(request.Keyword, request.PageIndex, request.PageSize);
                return result;
            }
        }

        private async Task<ViewModels.Common.PagedResult<ComicViewModel>> GetComicByComicName(string? comicName, int pageIndex, int pageSize)
        {
            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        join s in _context.Statuses on cd.StatusId equals s.StatusId
                        orderby c.ComicId descending
                        where c.IsDeleted == false && c.ApprovalStatus == ApprovalStatusEnum.Approved
                        select new { c, cd, s };

            if (!string.IsNullOrEmpty(comicName))
                query = query.Where(x => x.c.ComicName.Contains(comicName));

            int totalRow = await query.CountAsync();
            var data = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize)
            .Select(x => new ComicViewModel()
            {
                ComicId = x.c.ComicId,
                ComicName = x.c.ComicName,
                DateCreated = x.c.DateCreated,
                Alternative = x.c.Alternative,
                ViewCount = x.c.ViewCount,
                ComicCoverImageURL = x.c.ComicCoverImageURL,
                NewChapterId = x.c.NewChapterId,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                Rating = x.c.Rating,
                IsDeleted = x.c.IsDeleted,
                Status = ((ComicStatusEnum)x.s.StatusId).ToString()
            }).ToListAsync();

            var pagedResult = new ViewModels.Common.PagedResult<ComicViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = pageSize,
                PageIndex = pageIndex,
                Items = data
            };

            return pagedResult;
        }

        public async Task<List<ComicViewModel>> GeComicByNewComics(PagingRequestBase request)
        {
            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        join s in _context.Statuses on cd.StatusId equals s.StatusId
                        where c.IsDeleted == false && c.ApprovalStatus == ApprovalStatusEnum.Approved
                        orderby c.DateCreated descending
                        select new { c, cd, s };

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new ComicViewModel()
            {
                ComicId = x.c.ComicId,
                ComicName = x.c.ComicName,
                DateCreated = x.c.DateCreated,
                Alternative = x.c.Alternative,
                ViewCount = x.c.ViewCount,
                ComicCoverImageURL = x.c.ComicCoverImageURL,
                NewChapterId = x.c.NewChapterId,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                Rating = x.c.Rating,
                Status = x.s.StatusName
            }).ToListAsync();

            return data;
        }

        public async Task<ComicRankingViewModel> GetComicByRankingComics(int numberOfElement)
        {
            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        join s in _context.Statuses on cd.StatusId equals s.StatusId
                        where c.IsDeleted == false && c.ApprovalStatus == ApprovalStatusEnum.Approved
                        orderby c.ViewCount descending
                        select new { c, cd, s };

            var comic = await query.Select(x => new ComicRankingCalculatorViewModel()
            {
                ComicId = x.c.ComicId,
                ComicName = x.c.ComicName,
                DateCreated = x.c.DateCreated,
                Alternative = x.c.Alternative,
                ViewCount = x.c.ViewCount,
                ComicCoverImageURL = x.c.ComicCoverImageURL,
                NewChapterId = x.c.NewChapterId,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                Rating = x.c.Rating,
                Status = x.s.StatusName
            }).ToListAsync();

            var comicRanking = new ComicRankingViewModel();

            comicRanking.HotComicsOfTheDay = comic.OrderByDescending(x => x.PointDay).Take(numberOfElement).ToList();
            comicRanking.HotComicsOfTheWeek = comic.OrderByDescending(x => x.PointWeek).Take(numberOfElement).ToList();
            comicRanking.HotComicsOfTheMonth = comic.OrderByDescending(x => x.PointMonth).Take(numberOfElement).ToList();
            comicRanking.HotComicsOfTheYears = comic.OrderByDescending(x => x.PointYear).Take(numberOfElement).ToList();


            return comicRanking;
        }

        public async Task<PagingResult<ComicManagementViewModel>> GetPagingManagement(PagingRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return new PagingResult<ComicManagementViewModel>();

            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        select new { c, cd };

            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();

            if (!notACreator.ResultObj)
                query = query.Where(x => x.c.CreatedBy == userResult.ResultObj);

            var comicViewModels = await query.OrderByDescending(x => x.c.ComicId).Select(x => new ComicManagementViewModel()
            {
                ComicId = x.c.ComicId,
                ComicName = x.c.ComicName,
                DateCreated = x.c.DateCreated,
                Alternative = x.c.Alternative,
                ViewCount = x.c.ViewCount,
                ComicCoverImageURL = x.c.ComicCoverImageURL,
                NewChapterId = x.c.NewChapterId,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                Rating = x.c.Rating,
                IsDeleted = x.c.IsDeleted,
                ApprovalStatus = x.c.ApprovalStatus,
                DateApproved = x.c.DateApproved
            }).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                comicViewModels = await query.Select(x => new ComicManagementViewModel()
                {
                    ComicId = x.c.ComicId,
                    ComicName = x.c.ComicName,
                    DateCreated = x.c.DateCreated,
                    Alternative = x.c.Alternative,
                    ViewCount = x.c.ViewCount,
                    ComicCoverImageURL = x.c.ComicCoverImageURL,
                    NewChapterId = x.c.NewChapterId,
                    ComicSEOAlias = x.cd.ComicSEOAlias,
                    Rating = x.c.Rating,
                    IsDeleted = x.c.IsDeleted,
                    ApprovalStatus = x.c.ApprovalStatus,
                    DateApproved = x.c.DateApproved
                })
                .OrderBy(x => x.ApprovalStatus)
                .ThenBy(request.SortColumn + " " + request.SortColumnDirection)
                .ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                comicViewModels = comicViewModels.Where(x => x.ComicName.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = comicViewModels.Count();
            var data = comicViewModels.Skip(request.Skip).Take(request.PageSize).ToList();


            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<ComicManagementViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }
        #endregion

        public async Task<int> AddViewCount(int comicId)
        {
            var comic = await _context.Comics.FindAsync(comicId);
            if (comic != null)
            {
                comic.ViewCount += 1;
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Creates a new comic.
        /// </summary>
        /// <param name="request">The request containing the details of the comic to be created.</param>
        /// <returns></returns>
        public async Task<ApiResult<int>> CreateComic(CreateComicRequest request)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var userResult = _userContextService.GetUserIdFromToken();
                    if (!userResult.IsSuccessed)
                        return userResult.MapToResult<int>();

                    var comic = new Comic()
                    {
                        ComicName = request.ComicName,
                        Alternative = request.Alternative,
                        ViewCount = 0,
                        CountFollow = 0,
                        CountRating = 0,
                        Rating = 0,
                        ComicCoverImageURL = request.ComicCoverImageURL,
                        NewChapterId = null,
                        IsDeleted = false,
                        DateCreated = DateTime.Now,
                        CreatedBy = userResult.ResultObj,
                        ApprovalStatus = ApprovalStatusEnum.Sent,
                        DateApproved = null,
                        UserIdApproved = null,
                        ComicDetail = new ComicDetail()
                        {
                            StatusId = (int)ComicStatusEnum.New,
                            Summary = request.Summary,
                            ComicSEOSummary = request.ComicSEOSummary,
                            ComicSEOTitle = request.ComicSEOTitle,
                            ComicSEOAlias = _commonService.ConvertTitleToSEOAlias(request.ComicName),
                            IsDeleted = false,
                            DateCreated = DateTime.Now,
                            CreatedBy = userResult.ResultObj
                        }
                    };

                    var isAdminOrTeamMember = _userContextService.CheckUserRoleAdminOrTeamMember();
                    if (isAdminOrTeamMember.ResultObj)
                    {
                        comic.ApprovalStatus = ApprovalStatusEnum.Approved;
                        comic.UserIdApproved = userResult.ResultObj;
                        comic.DateApproved = DateTime.Now;
                    }

                    await _context.Comics.AddAsync(comic);
                    await _context.SaveChangesAsync();

                    if (request.Artists?.Count > 0)
                    {
                        var artistInComicDetails = request.Artists.Select(item => new ArtistInComicDetail
                        {
                            ArtistId = item,
                            ComicDetailId = comic.ComicDetail.ComicDetailId
                        });

                        await _context.ArtistInComicDetails.AddRangeAsync(artistInComicDetails);
                        await _context.SaveChangesAsync();
                    }

                    if (request.Authors?.Count > 0)
                    {
                        var authorInComicDetails = request.Authors.Select(item => new AuthorInComicDetail
                        {
                            AuthorId = item,
                            ComicDetailId = comic.ComicDetail.ComicDetailId
                        });

                        await _context.AuthorInComicDetails.AddRangeAsync(authorInComicDetails);
                        await _context.SaveChangesAsync();
                    }

                    if (request.Genres?.Count > 0)
                    {
                        var genreInComicDetails = request.Genres.Select(item => new GenreInComicDetail
                        {
                            GenreId = item,
                            ComicDetailId = comic.ComicDetail.ComicDetailId
                        });

                        await _context.GenreInComicDetails.AddRangeAsync(genreInComicDetails);
                        await _context.SaveChangesAsync();
                    }

                    transaction.Commit();

                    //creator send notification -> to admin, team members
                    if (!isAdminOrTeamMember.ResultObj)
                    {
                        var createNotificationRequest = new CreateNotificationRequest()
                        {
                            Actions = comic.ComicDetail.ComicSEOAlias,
                            ComicId = comic.ComicId,
                            ImageURL = comic.ComicCoverImageURL,
                            IsRead = false,
                            Title = $"Request for approval of the comic '<strong>{comic.ComicName}</strong>'",
                            Message = $"Request for approval of the comic '{comic.ComicName}'",
                        };

                        var resultCreateNotification = await _notificationService.CreateNotification(createNotificationRequest, NotificationTypeEnum.RequestApproval);
                    }

                    return new ApiSuccessResult<int>()
                    {
                        ResultObj = comic.ComicDetail.ComicDetailId,
                        Message = MessageConstants.CreateSuccess("Comic")
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new ApiErrorResult<int>() { Message = ex.Message };
                }
            }
        }

        /// <summary>
        /// feature: crawl comics
        /// (createdby) not added yet
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<int>> CreateComicByCrawling(CreateComicByCrawlingRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<int>();

            var comic = new Comic()
            {
                ComicName = request.ComicName,
                Alternative = request.Alternative,
                ViewCount = 0,
                CountFollow = 0,
                CountRating = 0,
                Rating = 0,
                ComicCoverImageURL = request.ComicCoverImageURL,
                NewChapterId = null,
                DateCreated = DateTime.Now,
                IsDeleted = false,
                CreatedBy = userResult.ResultObj,
                DateApproved = DateTime.Now,
                ApprovalStatus = ApprovalStatusEnum.Approved,
                UserIdApproved = userResult.ResultObj
            };
            await _context.Comics.AddAsync(comic);
            await _context.SaveChangesAsync();

            var comicDetail = new ComicDetail()
            {
                ComicId = comic.ComicId,
                StatusId = 1,
                ComicDetailCoverImageURL = request.ComicDetailCoverImageURL,
                Summary = request.Summary,
                ComicSEOSummary = "Read " + request.ComicName + " - HIKICOMIC",
                ComicSEOTitle = request.ComicName + " - HIKICOMIC",
                ComicSEOAlias = _commonService.ConvertTitleToSEOAlias(request.ComicName),
                IsDeleted = false,
                DateCreated = DateTime.Now,
                CreatedBy = new Guid("0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F")
            };
            await _context.ComicDetails.AddAsync(comicDetail);
            await _context.SaveChangesAsync();

            if (request.Artists?.Count > 0)
            {
                foreach (var artistName in request.Artists)
                {
                    var checkArtistExists = await _context.Artists.FirstOrDefaultAsync(x => x.ArtistName.ToLower().Trim() == artistName.ToLower().Trim());

                    if (checkArtistExists is null)
                    {
                        var artist = new Artist()
                        {
                            ArtistName = artistName,
                            Alternative = artistName,
                            Summary = "Updating artist" + artistName,
                            ArtistSEOAlias = _commonService.ConvertTitleToSEOAlias(artistName),
                            ArtistSEOSummary = "Read comics  by aritst " + artistName + " - HIKICOMIC",
                            ArtistSEOTitle = artistName + " - HIKICOMIC",
                            DateCreated = DateTime.Now,
                            IsDeleted = false,
                            CreatedBy = new Guid("0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F")
                        };

                        await _context.Artists.AddAsync(artist);
                        await _context.SaveChangesAsync();

                        var artistInComicDetail = new ArtistInComicDetail()
                        {
                            ArtistId = artist.ArtistId,
                            ComicDetailId = comicDetail.ComicDetailId
                        };

                        await _context.ArtistInComicDetails.AddAsync(artistInComicDetail);
                        await _context.SaveChangesAsync();

                    }
                    else
                    {
                        var artistInComicDetail = new ArtistInComicDetail()
                        {
                            ArtistId = checkArtistExists.ArtistId,
                            ComicDetailId = comicDetail.ComicDetailId
                        };

                        await _context.ArtistInComicDetails.AddAsync(artistInComicDetail);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            if (request.Authors?.Count > 0)
            {
                foreach (var authorName in request.Authors)
                {
                    var checkAuthorExists = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorName.ToLower().Trim() == authorName.ToLower().Trim());

                    if (checkAuthorExists is null)
                    {
                        var author = new Author()
                        {
                            AuthorName = authorName,
                            Alternative = authorName,
                            Summary = "Updating author " + authorName,
                            AuthorSEOAlias = _commonService.ConvertTitleToSEOAlias(authorName),
                            AuthorSEOSummary = "Read comics  by author " + authorName + " - HIKICOMIC",
                            AuthorSEOTitle = authorName + " - HIKICOMIC",
                            DateCreated = DateTime.Now,
                            IsDeleted = false,
                            CreatedBy = new Guid("0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F")
                        };

                        await _context.Authors.AddAsync(author);
                        await _context.SaveChangesAsync();

                        var authorInComicDetail = new AuthorInComicDetail()
                        {
                            AuthorId = author.AuthorId,
                            ComicDetailId = comicDetail.ComicDetailId
                        };

                        await _context.AuthorInComicDetails.AddAsync(authorInComicDetail);
                        await _context.SaveChangesAsync();

                    }
                    else
                    {
                        var authorInComicDetail = new AuthorInComicDetail()
                        {
                            AuthorId = checkAuthorExists.AuthorId,
                            ComicDetailId = comicDetail.ComicDetailId
                        };

                        await _context.AuthorInComicDetails.AddAsync(authorInComicDetail);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            if (request.Genres?.Count > 0)
            {
                foreach (var genreName in request.Genres)
                {
                    var queryGenres = from g in _context.Genres
                                      join gd in _context.GenreDetails on g.GenreId equals gd.GenreId
                                      where gd.GenreName.ToLower().Trim() == genreName.ToLower().Trim()
                                      select new { g, gd };

                    var checkGenreExists = await queryGenres.Select(x => new GenreDetail()
                    {
                        GenreId = x.gd.GenreId,
                        GenreDetailId = x.gd.GenreDetailId,
                        GenreName = x.gd.GenreName,
                        Summary = x.gd.Summary,
                        GenreSEOAlias = x.gd.GenreSEOAlias,
                        GenreSEOSummary = x.gd.GenreSEOSummary,
                        GenreSEOTitle = x.gd.GenreSEOTitle
                    }).FirstOrDefaultAsync();

                    if (checkGenreExists is null)
                    {
                        var genre = new Genre()
                        {
                            GenreParentId = null,
                            GenreImageURL = "",
                            IsShowHome = true,
                            IsDeleted = false,
                            DateCreated = DateTime.Now,
                            CreatedBy = new Guid("0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F")
                        };

                        await _context.Genres.AddAsync(genre);
                        await _context.SaveChangesAsync();

                        var genreDetail = new GenreDetail()
                        {
                            GenreId = genre.GenreId,
                            GenreName = genreName,
                            Summary = "Updating genre " + genreName,
                            GenreSEOAlias = _commonService.ConvertTitleToSEOAlias(genreName),
                            GenreSEOSummary = "Read comics  by genre " + genreName + " - HIKICOMIC",
                            GenreSEOTitle = genreName + " - HIKICOMIC",
                            CreatedBy = new Guid("0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F")
                        };

                        await _context.GenreDetails.AddAsync(genreDetail);
                        await _context.SaveChangesAsync();

                        var genreInComicDetail = new GenreInComicDetail()
                        {
                            GenreId = genre.GenreId,
                            ComicDetailId = comicDetail.ComicDetailId
                        };

                        await _context.GenreInComicDetails.AddAsync(genreInComicDetail);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var genreInComicDetail = new GenreInComicDetail()
                        {
                            GenreId = checkGenreExists.GenreId,
                            ComicDetailId = comicDetail.ComicDetailId
                        };

                        await _context.GenreInComicDetails.AddAsync(genreInComicDetail);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return new ApiSuccessResult<int>() { ResultObj = comicDetail.ComicDetailId, Message = MessageConstants.CreateSuccess("Comic") };
        }

        public async Task<ApiResult<bool>> DeleteComic(int comicId)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var comic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == comicId);
            if (comic is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!notACreator.ResultObj)
            {
                if (comic.CreatedBy != userResult.ResultObj)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
            }

            comic.IsDeleted = true;
            comic.DateUpdated = DateTime.Now;
            comic.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess("Comic") };
        }

        public async Task<ApiResult<bool>> DeleteComics(DeleteComicRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var validComicIds = request.ComicIds.Where(id => id > 0).ToList();

            var existingComics = await _context.Comics
                .Where(x => validComicIds.Contains(x.ComicId))
                .ToListAsync();

            var errorMessageBuilder = new StringBuilder();
            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();

            foreach (var comic in existingComics)
            {
                if (!notACreator.ResultObj)
                {
                    if (comic.CreatedBy != userResult.ResultObj)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
                }

                if (comic.IsDeleted == true)
                {
                    errorMessageBuilder.AppendLine("Comic with Id: " + comic.ComicId + " deleted.");
                }
                else
                {
                    comic.IsDeleted = true;
                    comic.DateUpdated = DateTime.Now;
                    comic.UpdatedBy = userResult.ResultObj;
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
                return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess(nameof(Comic)) };
            }
        }

        /// <summary>
        /// Update Comics
        /// </summary>
        /// <param name="request"></param>
        /// <param name="comicId"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> UpdateComic(UpdateComicRequest request, int comicId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var comic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == comicId);
            if (comic == null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!notACreator.ResultObj)
            {
                if (comic.CreatedBy != userResult.ResultObj)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
            }

            var comicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicId == comicId);
            if (comicDetail == null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

            string newSeoAlias = _commonService.ConvertTitleToSEOAlias(request.ComicName);

            // Update data table Comics
            comic.ComicName = request.ComicName;
            comic.Alternative = request.Alternative;
            comic.ComicCoverImageURL = request.ComicCoverImageURL;
            comic.DateUpdated = DateTime.Now;
            comic.UpdatedBy = userResult.ResultObj;

            // Update data ComicDetails
            comicDetail.ComicSEOTitle = request.ComicSEOTitle;
            comicDetail.ComicSEOSummary = request.ComicSEOSummary;
            comicDetail.Summary = request.Summary;
            comicDetail.ComicSEOAlias = newSeoAlias;
            comicDetail.StatusId = request.StatusId;
            comicDetail.DateUpdated = DateTime.Now;
            comicDetail.UpdatedBy = userResult.ResultObj;

            // Remove existing related entities
            _context.ArtistInComicDetails.RemoveRange(await _context.ArtistInComicDetails.Where(x => x.ComicDetailId == comicDetail.ComicDetailId).ToListAsync());
            _context.AuthorInComicDetails.RemoveRange(await _context.AuthorInComicDetails.Where(x => x.ComicDetailId == comicDetail.ComicDetailId).ToListAsync());
            _context.GenreInComicDetails.RemoveRange(await _context.GenreInComicDetails.Where(x => x.ComicDetailId == comicDetail.ComicDetailId).ToListAsync());

            // Add new related entities
            if (request.Artists?.Count > 0)
            {
                var artistInComicDetails = request.Artists.Select(item => new ArtistInComicDetail
                {
                    ArtistId = item,
                    ComicDetailId = comicDetail.ComicDetailId
                });

                await _context.ArtistInComicDetails.AddRangeAsync(artistInComicDetails);
            }

            if (request.Authors?.Count > 0)
            {
                var authorInComicDetails = request.Authors.Select(item => new AuthorInComicDetail
                {
                    AuthorId = item,
                    ComicDetailId = comicDetail.ComicDetailId
                });

                await _context.AuthorInComicDetails.AddRangeAsync(authorInComicDetails);
            }

            if (request.Genres?.Count > 0)
            {
                var genreInComicDetails = request.Genres.Select(item => new GenreInComicDetail
                {
                    GenreId = item,
                    ComicDetailId = comicDetail.ComicDetailId
                });

                await _context.GenreInComicDetails.AddRangeAsync(genreInComicDetails);
            }

            // Update related chapters
            var chapters = await _context.Chapters.Where(x => x.ComicDetailId == comicDetail.ComicDetailId).ToListAsync();
            foreach (var item in chapters)
            {
                item.ComicSEOAlias = newSeoAlias;
                item.DateUpdated = DateTime.Now;
                item.UpdatedBy = userResult.ResultObj;
            }

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.UpdateSuccess("Comic") };
        }

        public async Task<ApiResult<bool>> RestoreDeletedComic(int comicId)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var checkComicExits = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == comicId);
            if (checkComicExits == null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Comic"));

            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!notACreator.ResultObj)
            {
                if (checkComicExits.CreatedBy != userResult.ResultObj)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
            }

            if (!checkComicExits.IsDeleted)
                return new ApiErrorResult<bool>() { Message = MessageConstants.CurrentObjectDeleted("Comic") };

            checkComicExits.IsDeleted = false;
            checkComicExits.DateUpdated = DateTime.Now;
            checkComicExits.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>(MessageConstants.RestoreObjectSuccess("Comic"));
        }

        public async Task<ViewModels.Common.PagedResult<ComicViewModel>> GetComicByCreatorPaging(ComicByCreatorPagingRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return new ViewModels.Common.PagedResult<ComicViewModel>();

            if (userResult.ResultObj != Guid.Empty)
            {
                var query = from c in _context.Comics
                            join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                            join s in _context.Statuses on cd.StatusId equals s.StatusId
                            orderby c.ComicId descending
                            where c.IsDeleted == false && c.CreatedBy == userResult.ResultObj && c.ApprovalStatus == ApprovalStatusEnum.Approved
                            select new { c, cd, s };

                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.c.ComicName.Contains(request.Keyword));

                int totalRow = await query.CountAsync();

                var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                  .Select(x => new ComicViewModel()
                  {
                      ComicId = x.c.ComicId,
                      ComicName = x.c.ComicName,
                      DateCreated = x.c.DateCreated,
                      Alternative = x.c.Alternative,
                      ViewCount = x.c.ViewCount,
                      ComicCoverImageURL = x.c.ComicCoverImageURL,
                      NewChapterId = x.c.NewChapterId,
                      ComicSEOAlias = x.cd.ComicSEOAlias,
                      Rating = x.c.Rating,
                      IsDeleted = x.c.IsDeleted,
                      Status = x.s.StatusName
                  }).ToListAsync();

                var pagedResult = new ViewModels.Common.PagedResult<ComicViewModel>()
                {
                    TotalRecords = totalRow,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Items = data
                };
                return pagedResult;
            }
            else
            {
                var result = await GetComicByComicName(request.Keyword, request.PageIndex, request.PageSize);
                return result;
            }
        }

        #region Content-based Filtering Comics
        public async Task<List<ComicViewModel>> GetRecommendedComic(Guid userId, int numRecommendations)
        {
            // Get the most recent comics read by the user
            var recentComics = await GetRecentComics(userId, 3);

            // Get the genres of the recent comics
            var recentGenres = recentComics.SelectMany(c => c.ComicDetail.GenreInComicDetails.Select(gc => gc.GenreId)).Distinct().ToList();

            // Calculate the similarity scores between recent comics and all other comics
            var similarityScores = new Dictionary<int, double>();
            foreach (var comic in _context.Comics.Include(c => c.ComicDetail.GenreInComicDetails).Where(c => !c.IsDeleted && c.ApprovalStatus == ApprovalStatusEnum.Approved))
            {
                if (!recentComics.Contains(comic))
                {
                    double score = CalculateSimilarity(recentGenres, comic);
                    similarityScores.Add(comic.ComicId, score);
                }
            }

            // Sort the comics based on similarity scores and get the top recommendations
            var recommendedComics = similarityScores.OrderByDescending(x => x.Value)
                                                   .Take(numRecommendations)
                                                   .Select(x => x.Key)
                                                   .ToList();

            // Retrieve the recommended comics from the context
            var comics = recommendedComics.Select(id => new { Id = id, Index = recommendedComics.IndexOf(id) })
                              .OrderBy(x => x.Index)
                              .Select(x => x.Id)
                              .Join(_context.Comics.Include(c => c.ComicDetail.GenreInComicDetails),
                                    id => id,
                                    comic => comic.ComicId,
                                    (id, comic) => comic)
                              .ToList();

            var data = comics.Select(x => new ComicViewModel()
            {
                ComicId = x.ComicId,
                ComicName = x.ComicName,
                DateCreated = x.DateCreated,
                Alternative = x.Alternative,
                ViewCount = x.ViewCount,
                ComicCoverImageURL = x.ComicCoverImageURL,
                NewChapterId = x.NewChapterId,
                ComicSEOAlias = x.ComicDetail.ComicSEOAlias,
                Rating = x.Rating
            }).ToList();

            return data;
        }

        private async Task<List<Comic>> GetRecentComics(Guid userId, int numComics)
        {
            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        join s in _context.Statuses on cd.StatusId equals s.StatusId
                        join h in _context.UserComicReadingHistories on c.ComicId equals h.ComicId
                        join cc in _context.Chapters on h.ChapterId equals cc.ChapterId
                        where h.AppUserId == userId
                        orderby h.DateRead descending
                        select c;

            var comics = await query.Include(c => c.ComicDetail.GenreInComicDetails)
                            .ThenInclude(gc => gc.Genre)
                            .ToListAsync();

            var newComics = comics.DistinctBy(x => x.ComicId).ToList();

            var data = newComics.Take(numComics).ToList();

            return data;
        }

        private double CalculateSimilarity(List<int> genres, Comic comic)
        {
            // Calculate the similarity score between the genres of recent comics and the given comic
            var comicGenres = comic.ComicDetail.GenreInComicDetails.Select(gc => gc.GenreId).ToList();
            double intersectionCount = genres.Intersect(comicGenres).Count();
            double unionCount = genres.Union(comicGenres).Count();
            double similarity = intersectionCount / unionCount;
            return similarity;
        }
        #endregion

        public async Task<ApiResult<bool>> ApproveComic(int comicId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var comic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == comicId);
            if (comic is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

            comic.DateApproved = DateTime.Now;
            comic.ApprovalStatus = ApprovalStatusEnum.Approved;
            comic.UserIdApproved = userResult.ResultObj;

            await _context.SaveChangesAsync();

            //-> send notification
            var createNotificationRequest = new CreateNotificationRequest()
            {
                AppUserId = comic.CreatedBy,
                ComicId = comic.ComicId,
                ChapterId = null,
                Actions = "",
                ImageURL = comic.ComicCoverImageURL,
                IsRead = false,
                Title = $"HikiComic System approved your comic series.",
                Message = $"HikiComic System approved your comic series '<strong>{comic.ComicName}</strong>'.",
            };

            var resultCreateNotification = await _notificationService.CreateNotification(createNotificationRequest, NotificationTypeEnum.ResponseApproval);

            return new ApiSuccessResult<bool>() { Message = MessageConstants.ApproveSuccess };
        }

        public async Task<ApiResult<bool>> RejectComic(int comicId, string feedback)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var comic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == comicId);
            if (comic is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

            comic.DateApproved = DateTime.Now;
            comic.ApprovalStatus = ApprovalStatusEnum.Rejected;
            comic.UserIdApproved = userResult.ResultObj;

            await _context.SaveChangesAsync();

            string notificationFeedback = String.IsNullOrEmpty(feedback) ? "" : $" The reason given was '{feedback}'";

            //-> send notification
            var createNotificationRequest = new CreateNotificationRequest()
            {
                AppUserId = comic.CreatedBy,
                ComicId = comic.ComicId,
                ChapterId = null,
                Actions = "",
                ImageURL = comic.ComicCoverImageURL,
                IsRead = false,
                Title = $"HikiComic System has rejected the approval of your comic series.",
                Message = $"HikiComic System has rejected the approval of your comic series '<strong>{comic.ComicName}</strong>'.{notificationFeedback}",
            };

            var resultCreateNotification = await _notificationService.CreateNotification(createNotificationRequest, NotificationTypeEnum.ResponseApproval);

            return new ApiSuccessResult<bool>() { Message = MessageConstants.RejectSuccess };
        }
    }
}
