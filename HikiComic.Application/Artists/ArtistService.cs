using HikiComic.Application.Base;
using HikiComic.Application.Common;
using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Artists;
using HikiComic.ViewModels.Artists.ArtistDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiComic.Application.Artists
{
    public class ArtistService : BaseService<Artist>, IArtistService
    {
        private readonly HikiComicDbContext _context;

        private readonly ICommonService _commonService;

        private readonly IUserContextService _userContextService;

        public ArtistService(HikiComicDbContext context, ICommonService commonService, IUserContextService userContextService) : base(context, userContextService)
        {
            _context = context;
            _commonService = commonService;
            _userContextService = userContextService;
        }

        public async Task<ApiResult<List<ArtistViewModel>>> GetAll()
        {
            var artists = await _context.Artists.Where(x => x.IsDeleted == false).Select(x => new ArtistViewModel()
            {
                ArtistId = x.ArtistId,
                ArtistName = x.ArtistName,
                Alternative = x.Alternative,
                ArtistSEOAlias = x.ArtistSEOAlias,
                DateCreated = x.DateCreated,
                IsDeleted = x.IsDeleted
            }).OrderByDescending(x => x.ArtistId).ToListAsync();

            return new ApiSuccessResult<List<ArtistViewModel>>() { ResultObj = artists, Message = MessageConstants.GetObjectSuccess("Artist") };
        }

        public async Task<ApiResult<ArtistViewModel>> GetArtistByArtistId(int artistId)
        {
            var query = from a in _context.Artists
                        where a.ArtistId == artistId
                        join cb in _context.Users on a.CreatedBy equals cb.Id into createdByGroup
                        from cb in createdByGroup.DefaultIfEmpty()
                        join ub in _context.Users on a.UpdatedBy equals ub.Id into updatedByGroup
                        from ub in updatedByGroup.DefaultIfEmpty()
                        select new { a, cb, ub };

            var artistViewModel = await query.Select(x => new ArtistViewModel()
            {
                ArtistId = x.a.ArtistId,
                ArtistName = x.a.ArtistName,
                Alternative = x.a.Alternative,
                Summary = x.a.Summary,
                ArtistSEOAlias = x.a.ArtistSEOAlias,
                ArtistSEOTitle = x.a.ArtistSEOTitle,
                ArtistSEOSummary = x.a.ArtistSEOSummary,
                IsDeleted = x.a.IsDeleted,
                DateCreated = x.a.DateCreated,
                UserNameCreatedBy = x.cb.UserName,
                DateUpdated = x.a.DateUpdated,
                UserNameUpdatedBy = x.ub.UserName
            }).FirstOrDefaultAsync();

            if (artistViewModel is null)
                return new ApiErrorResult<ArtistViewModel>(MessageConstants.ObjectNotFound("Artist"));

            return new ApiSuccessResult<ArtistViewModel>() { ResultObj = artistViewModel, Message = MessageConstants.GetObjectSuccess("Artist") };
        }

        public async Task<ApiResult<ArtistViewModel>> GetArtistByArtistSEOAlias(string artistSEOAlias)
        {

            var checkArtistAlreadyExists = await _context.Artists.FirstOrDefaultAsync((x) => x.ArtistSEOAlias == artistSEOAlias);

            if (checkArtistAlreadyExists is null)
                return new ApiErrorResult<ArtistViewModel>(MessageConstants.ObjectNotFound("Artist"));

            var artistViewModel = new ArtistViewModel()
            {
                ArtistId = checkArtistAlreadyExists.ArtistId,
                ArtistName = checkArtistAlreadyExists.ArtistName,
                Alternative = checkArtistAlreadyExists.Alternative,
                Summary = checkArtistAlreadyExists.Summary,
                ArtistSEOAlias = checkArtistAlreadyExists.ArtistSEOAlias,
                ArtistSEOTitle = checkArtistAlreadyExists.ArtistSEOTitle,
                ArtistSEOSummary = checkArtistAlreadyExists.ArtistSEOSummary,
                DateCreated = checkArtistAlreadyExists.DateCreated,
                IsDeleted = checkArtistAlreadyExists.IsDeleted
            };

            return new ApiSuccessResult<ArtistViewModel>() { ResultObj = artistViewModel, Message = MessageConstants.GetObjectSuccess("Artist") };
        }

        public async Task<PagingResult<ArtistViewModel>> GetPagingManagement(PagingRequest request)
        {
            var artistViewModels = await _context.Artists.Select(x => new ArtistViewModel()
            {
                ArtistId = x.ArtistId,
                ArtistName = x.ArtistName,
                Alternative = x.Alternative,
                Summary = x.Summary,
                ArtistSEOAlias = x.ArtistSEOAlias,
                ArtistSEOTitle = x.ArtistSEOTitle,
                ArtistSEOSummary = x.Summary,
                DateCreated = x.DateCreated,
                IsDeleted = x.IsDeleted
            }).OrderByDescending(x => x.ArtistId).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                artistViewModels = await _context.Artists.Select(x => new ArtistViewModel()
                {
                    ArtistId = x.ArtistId,
                    ArtistName = x.ArtistName,
                    Alternative = x.Alternative,
                    Summary = x.Summary,
                    ArtistSEOAlias = x.ArtistSEOAlias,
                    ArtistSEOTitle = x.ArtistSEOTitle,
                    ArtistSEOSummary = x.Summary,
                    DateCreated = x.DateCreated,
                    IsDeleted = x.IsDeleted
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                artistViewModels = artistViewModels.Where(x => x.ArtistName.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = artistViewModels.Count();
            var data = artistViewModels.Skip(request.Skip).Take(request.PageSize).ToList();

            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<ArtistViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }


        #region override method of BaseService
        protected override int GetObjectId(Artist entity)
        {
            return entity.ArtistId;
        }

        protected override Task<string> GetObjectName(object request)
        {
            if (request is CreateArtistRequest)
            {
                var entity = (CreateArtistRequest)request;

                return Task.FromResult(entity.ArtistName);
            }

            if (request is UpdateArtistRequest)
            {
                var entity = (UpdateArtistRequest)request;

                return Task.FromResult(entity.ArtistName);
            }

            return Task.FromResult("");
        }

        protected override Task<string> GetObjectName(Artist entity)
        {
            return Task.FromResult(entity.ArtistName);
        }

        protected override Task<Artist?> CreateObjectProperties(object request)
        {
            var createArtistRequest = request as CreateArtistRequest;

            if (createArtistRequest is null)
                return Task.FromResult<Artist?>(null);

            return Task.FromResult<Artist?>(new Artist()
            {
                ArtistName = createArtistRequest.ArtistName,
                Alternative = createArtistRequest.Alternative,
                Summary = createArtistRequest.Summary,
                ArtistSEOAlias = _commonService.ConvertTitleToSEOAlias(createArtistRequest.ArtistName),
                ArtistSEOSummary = createArtistRequest.ArtistSEOSummary,
                ArtistSEOTitle = createArtistRequest.ArtistSEOTitle
            });
        }

        protected override void UpdateObjectProperties(Artist existingObject, object request)
        {
            var updateRequest = (UpdateArtistRequest)request;

            existingObject.ArtistName = updateRequest.ArtistName;
            existingObject.Alternative = updateRequest.Alternative;
            existingObject.Summary = updateRequest.Summary;
            existingObject.ArtistSEOSummary = updateRequest.ArtistSEOSummary;
            existingObject.ArtistSEOTitle = updateRequest.ArtistSEOTitle;
            existingObject.ArtistSEOAlias = _commonService.ConvertTitleToSEOAlias(updateRequest.ArtistName);
        }
        #endregion
    }
}
