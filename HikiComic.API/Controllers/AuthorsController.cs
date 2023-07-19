using HikiComic.Application.Authors;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Authors.AuthorDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/authors")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAll();

            return Ok(authors);
        }

        [HttpPost("paging-management")]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authors = await _authorService.GetPagingManagement(request);

            return Ok(authors);
        }

        [HttpGet("get-author-by-author-id/{authorId}")]
        public async Task<IActionResult> GetAuthorByAuthorId(int authorId)
        {
            var result = await _authorService.GetAuthorByAuthorId(authorId);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-author-by-author-seo-alias/{seoAliasAuthor}")]
        public async Task<IActionResult> GetByAuthorSEOAlias(string authorSEOAlias)
        {
            var result = await _authorService.GetAuthorByAuthorSEOAlias(authorSEOAlias);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>(MessageConstants.ModelStateIsNotValid("Create Author")));

            var result = await _authorService.CreateObject(request);

            return Ok(result);
        }

        [HttpPut("update/{authorId}")]
        public async Task<IActionResult> UpdateAuthor(int authorId, UpdateAuthorRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update Author")));

            var result = await _authorService.UpdateObject(authorId, request);

            return Ok(result);
        }

        [HttpDelete("delete/{authorId}")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            var result = await _authorService.DeleteObject(authorId);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteAuthors([FromBody] DeleteAuthorsRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Authors")));

            return Ok(await _authorService.DeleteObjects(request.AuthorIds));
        }

        [HttpPost("restore")]
        public async Task<IActionResult> RestoreDeletedAuthor([FromBody] int authorId)
        {
            var result = await _authorService.RestoreDeletedObject(authorId);

            return Ok(result);
        }
    }
}
