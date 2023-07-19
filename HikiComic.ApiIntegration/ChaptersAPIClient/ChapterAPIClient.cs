using HikiComic.ViewModels.Chapters;
using HikiComic.ViewModels.Chapters.ChapterDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.ChaptersAPIClient
{
    public class ChapterAPIClient : BaseAPI, IChapterAPIClient
    {
        public ChapterAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<IList<ChapterViewModel>> GetChapter(string comicSEOAlias)
        {
            return await GetAsync<IList<ChapterViewModel>>("/api/chapters/get-chapters-by-comic-seo-alias/" + comicSEOAlias);
        }

        public async Task<ApiResult<bool>> DeleteChapter(int chapterId)
        {
            return await DeleteAsync<ApiResult<bool>>("/api/chapters/delete/" + chapterId);
        }

        public async Task<ApiResult<ChapterDetailViewModel>> GetChapterDetail(string comicSEOAlias, string chapterSEOAlias)
        {
            return await GetAsync<ApiResult<ChapterDetailViewModel>>("/api/chapters/chapter-detail/" + comicSEOAlias + "/" + chapterSEOAlias);
        }

        public async Task<ApiResult<bool>> UpdateChapter(UpdateChapterRequest request, int chapterId)
        {
            return await PutAsync<ApiResult<bool>, UpdateChapterRequest>(request, $"/api/chapters/update/{chapterId}");
        }

        public async Task<ApiResult<int>> CreateChapterAndChapterImageURLWithComicId(CreateChapterAndChapterImageURLRequest request, int comicDetailId)
        {
            return await PostAsync<ApiResult<int>, CreateChapterAndChapterImageURLRequest>(request, $"/api/chapters/create-chapter-and-chapter-image-url-with-comic-detail-id/{comicDetailId}");
        }

        public async Task<ApiResult<int>> CreateChapterAndChapterImageURLWithComicSEOAlias(CreateChapterAndChapterImageURLRequest request, string comicSEOAlias)
        {
            return await PostAsync<ApiResult<int>, CreateChapterAndChapterImageURLRequest>(request, $"/api/chapters/create-chapter-and-chapter-image-url-with-comic-seo-alias/{comicSEOAlias}");
        }

        public async Task<PagingResult<ChapterManagementViewModel>> GetPagingManagement(PagingRequest request, string comicSEOAlias)
        {
            return await PostAsync<PagingResult<ChapterManagementViewModel>, PagingRequest>(request, $"/api/chapters/paging-management/{comicSEOAlias}");
        }

        public async Task<ApiResult<bool>> DeleteChapters(DeleteChapterRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteChapterRequest>(request, $"/api/chapters/delete-multiple");
        }

        public async Task<ApiResult<bool>> RestoreDeletedChapter(int chapterId)
        {
            return await PostAsync<ApiResult<bool>, int>(chapterId, $"/api/chapters/restore");
        }

        public async Task<ApiResult<bool>> CheckUserPermissionForComic(string comicSEOAlias)
        {
            return await GetAsync<ApiResult<bool>>($"/api/chapters/check-user-permission-for-comic/{comicSEOAlias}");
        }

        public async Task<ApiResult<bool>> ApproveChapter(int chapterId)
        {
            return await PostAsync<ApiResult<bool>, int>(chapterId, $"/api/chapters/approve-chapter");
        }

        public async Task<ApiResult<bool>> RejectChapter(int chapterId, string feedback)
        {
            return await PostAsync<ApiResult<bool>, string>(feedback, $"/api/chapters/reject-chapter/{chapterId}");
        }
    }
}
