﻿using System.Threading.Tasks;
using invert_api.Models;
using invert_api.Models.Request;
using invert_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace invert_api.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly MessagesService _service;
        public MessagesController(MessagesService service)
        {
            _service = service;
        }

        [HttpPost("user")]
        public async Task<ObjectResult> GetMessages([FromBody]Request<string> uid)
        {
            var result = await _service.GetMessagesForUser(uid.Data);

            if (result.Success) return Ok(result.Data);

            else return NotFound(result.Error);
        }

        [HttpGet("all")]
        public async Task<ObjectResult> GetAllMessages()
        {
            var result = await _service.GetAllMessages();

            if (result.Success) return Ok(result.Data);

            else return NotFound(result.Error);
        }

        [HttpPost("select")]
        public async Task<ObjectResult> GetMessage([FromBody] Request<long> request)
        {
            var result = await _service.GetMessage(request.Data);

            if (result.Success) return Ok(result.Data);

            else return NotFound(result.Error);
        }

        [HttpPost("update")]
        public async Task<ObjectResult> AddOrUpdateMessage([FromBody]Request<MESSAGE> message)
        {
            if (message == default)
            {
                return BadRequest("Message is not specified.");
            }
            var result = await _service.AddOrUpdateMessage(message.Data);

            if (result.Success) return Ok(result.Data);

            else return BadRequest(result.Error);
        }

        [HttpPost("add-list")]
        public async Task<ObjectResult> AddTargetedList([FromBody] Request<TargetRequest> targetedList)
        {
            var result = await _service.AddTargetedList(targetedList.Data);

            if (result.Success) return Ok(true);

            else return BadRequest(result.Error);
        }
    }
}
