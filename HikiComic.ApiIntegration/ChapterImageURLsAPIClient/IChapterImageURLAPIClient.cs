using HikiComic.ViewModels.ChapterImageURLs;
using HikiComic.ViewModels.Common;

namespace HikiComic.ApiIntegration.ChapterImageURLsAPIClient
{
    public interface IChapterImageURLAPIClient
    {
        Task<ApiResult<ChapterImageURLViewModel>> GetChapterImageURLs(string comicSEOAlias, string chapterSEOAlias);
    }
}
