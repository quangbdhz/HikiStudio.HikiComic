using HikiComic.Application.SendSMSs;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/send-sms")]
    [ApiController]
    public class SendSMSsController : ControllerBase
    {
        private readonly ISendSMSService _sendSMSService;
        public SendSMSsController(ISendSMSService sendSMSService)
        {
            _sendSMSService = sendSMSService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> GetAll()
        {

            //var artists = await _sendSMSService.SendSMS("OTP Verify aaaaaaaaa", "+84379420807");
            var artists = await _sendSMSService.SendSMS("OTP Verify aaaaaaaaa", "+84708046010");

            return Ok(artists);
        }

    }
}
