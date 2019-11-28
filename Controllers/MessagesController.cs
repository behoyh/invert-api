using System.Collections.Generic;
using System.Threading.Tasks;
using invert_api.Models;
using invert_api.Models.Request;
using invert_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace invert_api.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        MessagesService _service;
        public MessagesController(MessagesService service)
        {
            _service = service;
        }

        [HttpPost("all")]
        public async Task<ObjectResult> GetAllMessages([FromBody]Request<string> uid)
        {
            var result = await _service.GetAllMessages(uid.Data);

            if (result.Success) return Ok(result.Data);

            else return NotFound(result.Error);
        }

        [HttpPost("update")]
        public async Task<ObjectResult> AddOrUpdateMessage([FromBody]Request<MESSAGE> message)
        {
            var result = await _service.AddOrUpdateMessage(message.Data);

            if (result.Success) return Ok(result.Data);

            else return NotFound(result.Error);
        }

        [HttpPost("add-list")]
        public async Task<ObjectResult> AddTargetedList([FromBody] Request<List<TARGET_MESSAGE>> targetedList)
        {
            var result = await _service.AddTargetedList(targetedList.Data);

            if (result.Success) return Ok(true);

            else return NotFound(result.Error);
        }
    }
}
