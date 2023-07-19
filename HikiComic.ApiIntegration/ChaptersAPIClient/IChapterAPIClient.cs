using HikiComic.ViewModels.Chapters;
using HikiComic.ViewModels.Chapters.ChapterDataRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.ApiIntegration.ChaptersAPIClient
{
    public interface IChapterAPIClient
    {
        Task<PagingResult<ChapterManagementViewModel>> GetPagingManagement(PagingRequest request, string comicSEOAlias);

        Task<IList<ChapterViewModel>> GetChapter(string comicSEOAlias);

        Task<ApiResult<ChapterDetailViewModel>> GetChapterDetail(string comicSEOAlias, string chapterSEOAlias);

        Task<ApiResult<int>> CreateChapterAndChapterImageURLWithComicId(CreateChapterAndChapterImageURLRequest request, int comicDetailId);

        Task<ApiResult<int>> CreateChapterAndChapterImageURLWithComicSEOAlias(CreateChapterAndChapterImageURLRequest request, string comicSEOAlias);

        Task<ApiResult<bool>> UpdateChapter(UpdateChapterRequest request, int chapterId);

        Task<ApiResult<bool>> DeleteChapter(int chapterId);

        Task<ApiResult<bool>> DeleteChapters(DeleteChapterRequest request);

        Task<ApiResult<bool>> RestoreDeletedChapter(int chapterId);

        Task<ApiResult<bool>> CheckUserPermissionForComic(string comicSEOAlias);

        Task<ApiResult<bool>> ApproveChapter(int chapterId);

        Task<ApiResult<bool>> RejectChapter(int chapterId, string feedback);
    }
}
