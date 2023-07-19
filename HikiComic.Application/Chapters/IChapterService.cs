using HikiComic.ViewModels.Chapters;
using HikiComic.ViewModels.Chapters.ChapterDataRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.Application.Chapters
{
    public interface IChapterService
    {
        Task<PagingResult<ChapterManagementViewModel>> GetPagingManagement(PagingRequest request, string comicSEOAlias);

        Task<ApiResult<IList<ChapterViewModel>>> GetChapterByComicDetailId(int comicDetailId);

        Task<ApiResult<IList<ChapterViewModel>>> GetChapterByComicDetailId(int comicDetailId, Guid userId);

        Task<ApiResult<IList<ChapterViewModel>>> GetChapterByComicSEOAlias(string comicSEOAlias);
        
        Task<ApiResult<IList<ChapterViewModel>>> GetChapterByComicSEOAlias(string comicSEOAlias, Guid userId);

        Task<ApiResult<bool>> AddViewCount(string comicSEOAlias, string chapterSEOAlias);

        Task<ApiResult<int>> CreateChapter(CreateChapterRequest request);

        Task<ApiResult<int>> CreateChapterAndChapterImageURLWithComicId(CreateChapterAndChapterImageURLRequest request, int comicDetailId);

        Task<ApiResult<int>> CreateChapterAndChapterImageURLWithComicSEOAlias(CreateChapterAndChapterImageURLRequest request, string comicSEOAlias);

        Task<ApiResult<bool>> DeleteChapter(int chapterId);

        Task<ApiResult<bool>> DeleteChapters(DeleteChapterRequest request);

        Task<ApiResult<ChapterDetailViewModel>> GetChapterDetail(string comicSEOAlias, string chapterSEOAlias);

        Task<ApiResult<bool>> UpdateChapter(UpdateChapterRequest request, int chapterId);

        Task<ApiResult<bool>> RestoreDeletedChapter(int chapterId);

        Task<ApiResult<bool>> CheckUserPermissionForComic(string comicSEOAlias);

        Task<ApiResult<bool>> ApproveChapter(int chapterId);

        Task<ApiResult<bool>> RejectChapter(int chapterId, string feedback);
    }
}
