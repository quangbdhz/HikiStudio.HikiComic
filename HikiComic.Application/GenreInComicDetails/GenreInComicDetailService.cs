using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.GenreInComicDetails.GenreInComicDetailDataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.GenreInComicDetails
{
    public class GenreInComicDetailService : IGenreInComicDetailService
    {
        private readonly HikiComicDbContext _context;

        public GenreInComicDetailService(HikiComicDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> CreateGenreInComicDetail(CreateGenreInComicDetailRequest request)
        {
            var checkGenreDetailAlreadyExits = await _context.GenreDetails.FirstOrDefaultAsync((x) => x.GenreId == request.GenreId);

            if (checkGenreDetailAlreadyExits == null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Genre") };


            var checkGenreInComicDetailExits = await _context.GenreInComicDetails.FirstOrDefaultAsync((x) => x.GenreId == checkGenreDetailAlreadyExits.GenreId && x.ComicDetailId == request.ComicDetailId);

            if (checkGenreInComicDetailExits != null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectAlreadyExists("Genre In Comic Detail") };

            var categoryInComicDetail = new GenreInComicDetail()
            {
                GenreId = checkGenreDetailAlreadyExits.GenreId,
                ComicDetailId = request.ComicDetailId
            };

            await _context.GenreInComicDetails.AddAsync(categoryInComicDetail);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.CreateSuccess("Genre In Comic Detail") };
        }

        public async Task<ApiResult<bool>> DeleteGenreInComicDetail(int genreId, int comicDetailId)
        {
            var checkGenreDetailAlreadyExitsInComicDetail = await _context.GenreInComicDetails.FirstOrDefaultAsync((x) => x.GenreId == genreId && x.ComicDetailId == comicDetailId);

            if (checkGenreDetailAlreadyExitsInComicDetail == null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Genre In Comic Detail") };

            _context.Remove(checkGenreDetailAlreadyExitsInComicDetail);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess("Genre In Comic Detail") };
        }

        public async Task<int> GetGenreByGenreName(string genreName)
        {
            var genre = await _context.GenreDetails.FirstOrDefaultAsync((x) => x.GenreName == genreName);

            if (genre == null)
                return -1;

            return genre.GenreId;
        }
    }
}
