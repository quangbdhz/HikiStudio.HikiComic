using HikiComic.Application.Genders;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genders.GenderDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/genders")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _genderService.GetAll();

            return Ok(result);
        }

        [HttpDelete("delete/{genderId}")]
        public async Task<IActionResult> DeleteGender(int genderId)
        {
            var result = await _genderService.DeleteObject(genderId);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteGenders([FromBody] DeleteGendersRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Genders")));

            return Ok(await _genderService.DeleteObjects(request.GenderIds));
        }

        [HttpPost("restore")]
        public async Task<IActionResult> RestoreDeletedGender([FromBody] int genderId)
        {
            var result = await _genderService.RestoreDeletedObject(genderId);

            return Ok(result);
        }
    }
}
