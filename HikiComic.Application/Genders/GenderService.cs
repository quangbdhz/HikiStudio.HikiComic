using HikiComic.Application.Base;
using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genders;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.Genders
{
    public class GenderService : BaseService<Gender>, IGenderService
    {
        private readonly HikiComicDbContext _context;

        private readonly IUserContextService _userContextService;

        public GenderService(HikiComicDbContext context, IUserContextService userContextService) : base(context, userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }
        public async Task<ApiResult<IList<GenderViewModel>>> GetAll()
        {
            var gender = await _context.Genders.Where(x => x.IsDeleted == false).Select(x => new GenderViewModel()
            {
                GenderId = x.GenderId,
                GenderName = x.GenderName
            }).ToListAsync();

            return new ApiSuccessResult<IList<GenderViewModel>>() { Message = MessageConstants.GetObjectSuccess("Genders"), ResultObj = gender };
        }

        #region override method of BaseService
        protected override Task<Gender?> CreateObjectProperties(object request)
        {
            throw new NotImplementedException();
        }

        protected override int GetObjectId(Gender entity)
        {
            return entity.GenderId;
        }

        protected override Task<string> GetObjectName(object request)
        {
            throw new NotImplementedException();
        }

        protected override Task<string> GetObjectName(Gender entity)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateObjectProperties(Gender existingObject, object request)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
