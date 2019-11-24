using System.Collections.Generic;
using System.Threading.Tasks;
using invert_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET api/values/5
        [HttpGet("all/{id}")]
        public async Task<ObjectResult> GetAllMessages(string uid)
        {
            var result = await _service.GetAllMessages(uid);

            if (result.Success) return Ok(result.Data);

            else return NotFound(result.Error);
        }
    }
}
