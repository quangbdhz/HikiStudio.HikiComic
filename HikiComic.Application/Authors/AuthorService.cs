using HikiComic.Application.Base;
using HikiComic.Application.Common;
using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Authors;
using HikiComic.ViewModels.Authors.AuthorDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiComic.Application.Authors
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        private readonly HikiComicDbContext _context;

        private readonly ICommonService _commonService;

        private readonly IUserContextService _userContextService;

        public AuthorService(HikiComicDbContext context, ICommonService commonService, IUserContextService userContextService) : base(context, userContextService)
        {
            _context = context;
            _commonService = commonService;
            _userContextService = userContextService;
        }

        public async Task<ApiResult<List<AuthorViewModel>>> GetAll()
        {
            var authors = await _context.Authors.Where(x => x.IsDeleted == false).Select(x => new AuthorViewModel()
            {
                AuthorId = x.AuthorId,
                AuthorName = x.AuthorName,
                Alternative = x.Alternative,
                AuthorSEOAlias = x.AuthorSEOAlias,
                DateCreated = x.DateCreated,
                IsDeleted = x.IsDeleted
            }).OrderByDescending(x => x.AuthorId).ToListAsync();

            return new ApiSuccessResult<List<AuthorViewModel>>() { ResultObj = authors, Message = MessageConstants.GetObjectSuccess("Author") };
        }

        public async Task<PagingResult<AuthorViewModel>> GetPagingManagement(PagingRequest request)
        {
            var authorViewModels = await _context.Authors.Select(x => new AuthorViewModel()
            {
                AuthorId = x.AuthorId,
                AuthorName = x.AuthorName,
                Alternative = x.Alternative,
                AuthorSEOAlias = x.AuthorSEOAlias,
                DateCreated = x.DateCreated,
                IsDeleted = x.IsDeleted
            }).OrderByDescending(x => x.AuthorId).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                authorViewModels = await _context.Authors.Select(x => new AuthorViewModel()
                {
                    AuthorId = x.AuthorId,
                    AuthorName = x.AuthorName,
                    Alternative = x.Alternative,
                    AuthorSEOAlias = x.AuthorSEOAlias,
                    DateCreated = x.DateCreated,
                    IsDeleted = x.IsDeleted
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                authorViewModels = authorViewModels.Where(x => x.AuthorName.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = authorViewModels.Count();
            var data = authorViewModels.Skip(request.Skip).Take(request.PageSize).ToList();


            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<AuthorViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        public async Task<ApiResult<AuthorViewModel>> GetAuthorByAuthorId(int authorId)
        {
            var query = from a in _context.Authors
                        where a.AuthorId == authorId
                        join cb in _context.Users on a.CreatedBy equals cb.Id into createdByGroup
                        from cb in createdByGroup.DefaultIfEmpty()
                        join ub in _context.Users on a.UpdatedBy equals ub.Id into updatedByGroup
                        from ub in updatedByGroup.DefaultIfEmpty()
                        select new { a, cb, ub };

            var authorViewModel = await query.Select(x => new AuthorViewModel()
            {
                AuthorId = x.a.AuthorId,
                AuthorName = x.a.AuthorName,
                Alternative = x.a.Alternative,
                Summary = x.a.Summary,
                AuthorSEOAlias = x.a.AuthorSEOAlias,
                AuthorSEOSummary = x.a.AuthorSEOSummary,
                AuthorSEOTitle = x.a.AuthorSEOTitle,
                IsDeleted = x.a.IsDeleted,
                DateCreated = x.a.DateCreated,
                UserNameCreatedBy = x.cb.UserName,
                DateUpdated = x.a.DateUpdated,
                UserNameUpdatedBy = x.ub.UserName
            }).FirstOrDefaultAsync();

            if (authorViewModel is null)
                return new ApiErrorResult<AuthorViewModel>(MessageConstants.ObjectNotFound("Author With Id: " + authorId));

            return new ApiSuccessResult<AuthorViewModel>() { ResultObj = authorViewModel, Message = MessageConstants.GetObjectSuccess("Author") };
        }

        public async Task<ApiResult<AuthorViewModel>> GetAuthorByAuthorSEOAlias(string authorSEOAlias)
        {
            var checkAuthorAlreadyExists = await _context.Authors.FirstOrDefaultAsync((x) => x.AuthorSEOAlias == authorSEOAlias);

            if (checkAuthorAlreadyExists is null)
                return new ApiErrorResult<AuthorViewModel>(MessageConstants.ObjectNotFound("Author With Seo Alias: " + authorSEOAlias));

            var authorViewModel = new AuthorViewModel()
            {
                AuthorId = checkAuthorAlreadyExists.AuthorId,
                DateCreated = checkAuthorAlreadyExists.DateCreated,
                Alternative = checkAuthorAlreadyExists.Alternative,
                IsDeleted = checkAuthorAlreadyExists.IsDeleted,
                AuthorName = checkAuthorAlreadyExists.AuthorName,
                AuthorSEOAlias = checkAuthorAlreadyExists.AuthorSEOAlias
            };

            return new ApiSuccessResult<AuthorViewModel>() { ResultObj = authorViewModel, Message = MessageConstants.GetObjectSuccess("Author") };
        }


        #region override method of BaseService
        protected override int GetObjectId(Author entity)
        {
            return entity.AuthorId;
        }

        protected override Task<string> GetObjectName(object request)
        {
            if (request is CreateAuthorRequest)
            {
                var entity = (CreateAuthorRequest)request;

                return Task.FromResult(entity.AuthorName);
            }

            if (request is UpdateAuthorRequest)
            {
                var entity = (UpdateAuthorRequest)request;

                return Task.FromResult(entity.AuthorName);
            }

            return Task.FromResult("");
        }

        protected override Task<string> GetObjectName(Author entity)
        {
            return Task.FromResult(entity.AuthorName);
        }

        protected override Task<Author?> CreateObjectProperties(object request)
        {
            var createAuthorRequest = request as CreateAuthorRequest;

            if (createAuthorRequest is null)
                return Task.FromResult<Author?>(null);

            var author = new Author()
            {
                AuthorName = createAuthorRequest.AuthorName,
                Alternative = createAuthorRequest.Alternative,
                Summary = createAuthorRequest.Summary,
                AuthorSEOAlias = _commonService.ConvertTitleToSEOAlias(createAuthorRequest.AuthorName),
                AuthorSEOSummary = createAuthorRequest.AuthorSEOSummary,
                AuthorSEOTitle = createAuthorRequest.AuthorSEOTitle
            };

            return Task.FromResult<Author?>(author);
        }

        protected override void UpdateObjectProperties(Author existingObject, object request)
        {
            var updateAuthorRequest = (UpdateAuthorRequest)request;

            existingObject.AuthorName = updateAuthorRequest.AuthorName;
            existingObject.Alternative = updateAuthorRequest.Alternative;
            existingObject.Summary = updateAuthorRequest.Summary;
            existingObject.AuthorSEOSummary = updateAuthorRequest.AuthorSEOSummary;
            existingObject.AuthorSEOTitle = updateAuthorRequest.AuthorSEOTitle;
            existingObject.AuthorSEOAlias = _commonService.ConvertTitleToSEOAlias(updateAuthorRequest.AuthorName);
        }
        #endregion
    }
}
