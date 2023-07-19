using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.AuthorInComicDetails.AuthorInComicDetailRequest;
using HikiComic.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.AuthorInComicDetails
{
    public class AuthorInComicDetailService : IAuthorInComicDetailService
    {
        private readonly HikiComicDbContext _context;

        public AuthorInComicDetailService(HikiComicDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> CreateAuthorInComicDetail(CreateAuthorInComicDetailRequest request)
        {
            var checkAuthorInComicDetailAlreadyExits = await _context.AuthorInComicDetails.FirstOrDefaultAsync((x) => x.ComicDetailId == request.ComicDetailId && x.AuthorId == request.AuthorId);

            if (checkAuthorInComicDetailAlreadyExits != null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectAlreadyExists("AuthorInComicDetail"));

            var authorInComicDetail = new AuthorInComicDetail() { AuthorId = request.AuthorId, ComicDetailId = request.ComicDetailId };

            await _context.AuthorInComicDetails.AddAsync(authorInComicDetail);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>(MessageConstants.CreateSuccess("AuthorInComicDetail"));
        }

        public async Task<ApiResult<bool>> DeleteAuthorInComicDetail(int authorId, int comicDetailId)
        {
            var checkAuthorInComicDetailAlreadyExits = await _context.AuthorInComicDetails.FirstOrDefaultAsync(x => x.AuthorId == authorId && x.ComicDetailId == comicDetailId);

            if (checkAuthorInComicDetailAlreadyExits is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("AuthorInComicDetail"));

            _context.AuthorInComicDetails.Remove(checkAuthorInComicDetailAlreadyExits);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>(MessageConstants.DeleteSuccess("AuthorInComicDetail"));
        }
    }
}
