using HikiComic.ViewModels.ChapterImageURLs;
using HikiComic.ViewModels.ChapterImageURLs.ChapterImageURLDataRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.Application.ChapterImageURLs
{
    public interface IChapterImageURLService
    {
        Task<ApiResult<ChapterImageURLViewModel>> GetChapterByChapterId(int chapterId, Guid? userId);

        Task<ApiResult<ChapterImageURLViewModel>> GetChapterByChapterComicSEOAlias(string comicSEOAlias, string chapterSEOAlias, Guid? userId);

        Task<ApiResult<ChapterImageURLViewModel>> GetFreeChapterByChapterComicSEOAlias(string comicSEOAlias, string chapterSEOAlias, Guid? userId);

        Task<ApiResult<string>> CreateChapterImageURL(CreateChapterImageURLRequest request);
    }
}
