using System.Threading.Tasks;
using invert_api.Models;
using invert_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace invert_api.Controllers
{
    [Route("api/[controller]")]
    public class BlobController : Controller
    {
        private readonly BlobService _blobService;

        public BlobController(BlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPut]
        public async Task<ObjectResult> PutBlob(BlobType type, [FromBody] byte[] content)
        {
            var result = await _blobService.Upload(content, type);

            if (result.Success) return Ok(result.Data);

            else return BadRequest(result.Error);
        }

        [HttpGet]
        public async Task<FileContentResult> GetBlob(long BLOB_ID)
        {
            var result = await _blobService.Get(BLOB_ID);

            return File(result, "image/png");
        }
    }
}
