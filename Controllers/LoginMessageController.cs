using invert_api.Models;
using invert_api.Models.Request;
using invert_api.Models.Response;
using invert_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace invert_api.Controllers
{
    public class LoginMessageController : Controller
    {
        public LoginMessageService _service;
        public LoginMessageController(LoginMessageService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<ObjectResult> GetAllMessages()
        {
            Response<LoginMessageResponse> result = await _service.GetAllMessages();

            if (result.Success) return Ok(result.Data);

            else return NotFound(result.Error);
        }

        [HttpPost("update")]
        public async Task<ObjectResult> AddOrUpdateMessage([FromBody]Request<LoginMessage> message)
        {
            Response<int> result = await _service.AddOrUpdateMessage(message.Data);

            if (result.Success) return Ok(result.Data);

            else return BadRequest(result.Error);
        }
    }
}
