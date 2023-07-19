using HikiComic.Application.Base;
using HikiComic.Application.Common;
using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genres;
using HikiComic.ViewModels.Genres.GenresDataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Text;

namespace HikiComic.Application.Genres
{
    public class GenreService : BaseService<Genre>, IGenreService
    {
        private readonly HikiComicDbContext _context;

        private readonly ICommonService _commonService;

        private readonly IUserContextService _userContextService;

        public GenreService(HikiComicDbContext context, ICommonService commonService, IUserContextService userContextService) : base(context, userContextService)
        {
            _context = context;
            _commonService = commonService;
            _userContextService = userContextService;
        }

        //get all Genre
        public async Task<ApiResult<List<GenreViewModel>>> GetAll()
        {
            var query = from g in _context.Genres
                        where g.IsDeleted == false
                        join gd in _context.GenreDetails on g.GenreId equals gd.GenreId
                        orderby gd.GenreName ascending
                        select new { g, gd };

            var result = await query.Select(x => new GenreViewModel()
            {
                GenreId = x.g.GenreId,
                GenreName = x.gd.GenreName,
                GenreSEOAlias = x.gd.GenreSEOAlias,
                GenreParentId = x.g.GenreParentId,
                IsShowHome = x.g.IsShowHome,
                GenreImageURL = x.g.GenreImageURL,
                IsDeleted = x.g.IsDeleted
            }).ToListAsync();

            if (result.Count == 0)
                return new ApiErrorResult<List<GenreViewModel>>() { Message = MessageConstants.ObjectNotFound("Genre") };

            return new ApiSuccessResult<List<GenreViewModel>>() { ResultObj = result };
        }

        private static string ShowLess(string? data)
        {
            if (String.IsNullOrEmpty(data))
                return "";

            if (data.Length > 30)
                return data.Substring(0, 29).TrimEnd() + "...";

            return data;
        }

        //get Genre by paging
        public async Task<PagingResult<GenreViewModel>> GetPagingManagement(PagingRequest request)
        {
            var query = from g in _context.Genres
                        join gd in _context.GenreDetails on g.GenreId equals gd.GenreId
                        orderby g.GenreId descending
                        select new { g, gd };

            var genreViewModels = await query.OrderByDescending(x => x.g.GenreId).Select(x => new GenreViewModel()
            {
                GenreId = x.g.GenreId,
                GenreName = x.gd.GenreName,
                GenreSEOAlias = x.gd.GenreSEOAlias,
                Summary = ShowLess(x.gd.Summary),
                GenreSEOSummary = ShowLess(x.gd.GenreSEOSummary),
                GenreSEOTitle = ShowLess(x.gd.GenreSEOTitle),
                GenreParentId = x.g.GenreParentId,
                GenreImageURL = x.g.GenreImageURL,
                IsDeleted = x.g.IsDeleted
            }).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                genreViewModels = await query.Select(x => new GenreViewModel()
                {
                    GenreId = x.g.GenreId,
                    GenreName = x.gd.GenreName,
                    GenreSEOAlias = x.gd.GenreSEOAlias,
                    Summary = ShowLess(x.gd.Summary),
                    GenreSEOSummary = ShowLess(x.gd.GenreSEOSummary),
                    GenreSEOTitle = ShowLess(x.gd.GenreSEOTitle),
                    GenreParentId = x.g.GenreParentId,
                    GenreImageURL = x.g.GenreImageURL,
                    IsDeleted = x.g.IsDeleted
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                genreViewModels = genreViewModels.Where(x => x.GenreName.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = genreViewModels.Count();
            var data = genreViewModels.Skip(request.Skip).Take(request.PageSize).ToList();


            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<GenreViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        public async Task<ApiResult<GenreViewModel>> GetGenreByGenreId(int genreId)
        {
            var query = from g in _context.Genres
                        join gd in _context.GenreDetails on g.GenreId equals gd.GenreId
                        join cb in _context.Users on g.CreatedBy equals cb.Id into createdByGroup
                        from cb in createdByGroup.DefaultIfEmpty()
                        join ub in _context.Users on g.UpdatedBy equals ub.Id into updatedByGroup
                        from ub in updatedByGroup.DefaultIfEmpty()
                        where g.GenreId == genreId
                        select new { g, gd, ub, cb };

            var result = await query.Select(x => new GenreViewModel()
            {
                GenreId = x.g.GenreId,
                GenreName = x.gd.GenreName,
                GenreSEOAlias = x.gd.GenreSEOAlias,
                Summary = x.gd.Summary,
                GenreSEOSummary = x.gd.GenreSEOSummary,
                GenreSEOTitle = x.gd.GenreSEOTitle,
                GenreParentId = x.g.GenreParentId,
                GenreImageURL = x.g.GenreImageURL,
                IsDeleted = x.g.IsDeleted,
                DateCreated = x.g.DateCreated,
                UserNameCreatedBy = x.cb.UserName,
                DateUpdated = x.g.DateUpdated,
                UserNameUpdatedBy = x.ub.UserName
            }).FirstOrDefaultAsync();

            if (result is null)
                return new ApiErrorResult<GenreViewModel>() { Message = MessageConstants.ObjectNotFound("Genre") };

            return new ApiSuccessResult<GenreViewModel>() { ResultObj = result, Message = MessageConstants.GetObjectSuccess("Genre") };
        }

        public async Task<ApiResult<GenreViewModel>> GetGenreByGenreSEOAlias(string genreSEOAlias)
        {
            genreSEOAlias = WebUtility.UrlDecode(genreSEOAlias);

            var query = from g in _context.Genres
                        where g.IsDeleted == false
                        join gd in _context.GenreDetails on g.GenreId equals gd.GenreId
                        where gd.GenreSEOAlias == genreSEOAlias
                        select new { g, gd };

            var result = await query.Select(x => new GenreViewModel()
            {
                GenreId = x.g.GenreId,
                GenreName = x.gd.GenreName,
                GenreSEOAlias = x.gd.GenreSEOAlias,
                Summary = x.gd.Summary,
                GenreSEOSummary = x.gd.GenreSEOSummary,
                GenreSEOTitle = x.gd.GenreSEOTitle,
                GenreParentId = x.g.GenreParentId,
                GenreImageURL = x.g.GenreImageURL,
                IsDeleted = x.g.IsDeleted
            }).FirstOrDefaultAsync();

            if (result == null)
                return new ApiErrorResult<GenreViewModel>() { Message = MessageConstants.ObjectNotFound("Genre") };

            return new ApiSuccessResult<GenreViewModel>(result) { Message = MessageConstants.GetObjectSuccess("Genre") };
        }

        public async Task<ApiResult<UpdateGenreRequest>> GetGenreByGenreSEOAliasToDoUpdate(string genreSEOAlias)
        {
            genreSEOAlias = WebUtility.UrlDecode(genreSEOAlias);

            var query = from g in _context.Genres
                        where g.IsDeleted == false
                        join gd in _context.GenreDetails on g.GenreId equals gd.GenreId
                        where gd.GenreSEOAlias == genreSEOAlias
                        select new { g, gd };

            var result = await query.Select(x => new UpdateGenreRequest()
            {
                Summary = x.gd.Summary,
                GenreSEOSummary = x.gd.GenreSEOSummary,
                GenreSEOTitle = x.gd.GenreSEOTitle,
            }).FirstOrDefaultAsync();

            if (result == null)
            {
                return new ApiErrorResult<UpdateGenreRequest>() { Message = MessageConstants.ObjectNotFound("Genre") };
            }
            return new ApiSuccessResult<UpdateGenreRequest>(result) { Message = MessageConstants.GetObjectSuccess("Genre") };
        }

        public async Task<ApiResult<List<GenreViewModel>>> GetGenreShowHome()
        {
            var query = from g in _context.Genres
                        where g.IsDeleted == false
                        join gd in _context.GenreDetails on g.GenreId equals gd.GenreId
                        where g.IsShowHome == true
                        orderby g.GenreId descending
                        select new { g, gd };

            var result = await query.Select(x => new GenreViewModel()
            {
                GenreId = x.g.GenreId,
                GenreName = x.gd.GenreName,
                GenreSEOAlias = x.gd.GenreSEOAlias,
                GenreParentId = x.g.GenreParentId,
                GenreImageURL = x.g.GenreImageURL,
                IsDeleted = x.g.IsDeleted
            }).ToListAsync();

            if (result.Count == 0)
                return new ApiErrorResult<List<GenreViewModel>>() { Message = MessageConstants.ObjectNotFound("Genre") };

            return new ApiSuccessResult<List<GenreViewModel>>() { ResultObj = result };
        }

        /// <summary>
        /// Creates a new genre with the specified details.
        /// </summary>
        /// <param name="request">The request object containing the genre details.</param>
        /// <returns></returns>
        public async Task<ApiResult<int>> CreateGenre(CreateGenreRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<int>();

            var checkGenreNameAlreadyExists = await _context.GenreDetails.FirstOrDefaultAsync(x => x.GenreName == request.GenreName);
            if (checkGenreNameAlreadyExists != null)
                return new ApiErrorResult<int>() { Message = MessageConstants.ObjectAlreadyExists("Genre"), ResultObj = checkGenreNameAlreadyExists.GenreId };

            var genreSEOTitle = !string.IsNullOrEmpty(request.GenreSEOTitle) ? request.GenreSEOTitle : "Genre " + request.GenreName + " - HikiComic";
            if (!genreSEOTitle.Contains(" - HikiComic"))
                genreSEOTitle += " - HikiComic";

            var genre = new Genre()
            {
                IsShowHome = request.IsShowHome,
                GenreParentId = request.GenreParentId,
                GenreImageURL = request.GenreImageURL,
                IsDeleted = false,
                DateCreated = DateTime.Now,
                CreatedBy = userResult.ResultObj,
                GenreDetail = new GenreDetail()
                {
                    GenreName = request.GenreName,
                    Summary = request.Summary,
                    GenreSEOAlias = _commonService.ConvertTitleToSEOAlias(request.GenreName),
                    GenreSEOSummary = request.GenreSEOSummary,
                    GenreSEOTitle = genreSEOTitle,
                    IsDeleted = false,
                    DateCreated = DateTime.Now,
                    CreatedBy = userResult.ResultObj
                }
            };

            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int> { Message = MessageConstants.CreateSuccess("Genre"), ResultObj = genre.GenreId };
        }

        public async Task<ApiResult<bool>> UpdateGenre(UpdateGenreRequest request, int genreId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var checkGenreExits = await _context.Genres.FirstOrDefaultAsync(x => x.GenreId == genreId);

            if (checkGenreExits == null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Genre"));

            var updateGenreDetail = await _context.GenreDetails.FirstOrDefaultAsync(x => x.GenreId == genreId);

            if (updateGenreDetail == null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("GenreDetail"));

            if (String.IsNullOrEmpty(request.GenreSEOTitle))
                request.GenreSEOTitle = "Genre " + updateGenreDetail.GenreName + " - HikiComic";

            if (!request.GenreSEOTitle.Contains(" - HikiComic"))
                request.GenreSEOTitle += " - HikiComic";

            updateGenreDetail.Summary = request.Summary;
            updateGenreDetail.GenreSEOTitle = request.GenreSEOTitle;
            updateGenreDetail.GenreSEOSummary = request.GenreSEOSummary;
            updateGenreDetail.DateUpdated = DateTime.Now;
            updateGenreDetail.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>(MessageConstants.UpdateSuccess("Genre"));
        }


        #region override method of BaseService
        protected override int GetObjectId(Genre entity)
        {
            return entity.GenreId;
        }

        protected override Task<string> GetObjectName(object request)
        {
            throw new NotImplementedException();
        }

        protected override Task<string> GetObjectName(Genre entity)
        {
            throw new NotImplementedException();
        }

        protected override Task<Genre?> CreateObjectProperties(object request)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateObjectProperties(Genre existingObject, object request)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
