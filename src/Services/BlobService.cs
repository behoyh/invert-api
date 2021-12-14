using System;
using System.Threading.Tasks;
using invert_api.Domains;
using invert_api.Models;
using invert_api.Models.Response;
using Microsoft.Extensions.Configuration;

namespace invert_api.Services
{
    public class BlobService
    {
        private readonly Blob _blob;
        private readonly IConfiguration _configuration;

        public BlobService(Blob blob, IConfiguration configuration)
        {
            _blob = blob;
            _configuration = configuration;
        }


        public async Task<Response<long>> Upload(byte[] blob, BlobType type)
        {
            var basePath = _configuration.GetValue<string>("BaseFileStorage");

            if (string.IsNullOrWhiteSpace(basePath))
            {
                basePath = Environment.CurrentDirectory + "/content/";
            }

            return await _blob.SaveBlob(basePath,blob,type);
        }

        public async Task<byte[]> Get(long blobid)
        {
            return await _blob.GetBlob(blobid);
        }
    }
}
