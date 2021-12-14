using System;
using System.IO;
using System.Threading.Tasks;
using invert_api.Models;
using invert_api.Models.Response;
using invert_api.Repositories;

namespace invert_api.Domains
{
    public class Blob
    {
        private readonly InsertBlobRepository _insertBlob;
        private readonly GetBlobRepository _getBlob;
        public Blob(InsertBlobRepository insertBlob, GetBlobRepository getBlob)
        {
            _insertBlob = insertBlob;
            _getBlob = getBlob;
        }

        public async Task<Response<long>> SaveBlob(string basePath, byte[] blob, BlobType type)
        {
            if(!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            var name = Guid.NewGuid() + "." + type.ToString();

            var filepath = basePath + name;

            File.WriteAllBytes(filepath, blob);

            var model = new BLOB()
            {
                Active = true,
                Path = filepath,
                Name = name,
                BlobType = type,
                Created = DateTime.Now,
                Modified = DateTime.Now
            };

            return await _insertBlob.UploadBlobAsync(model);
        }

        public async Task<byte[]> GetBlob(long blobid)
        {
            var result = await _getBlob.GetBlobAsync(blobid);

            if (!result.Success)
            {
                return new byte[0];
            }

            var filepath = result.Data.Path;

            return await File.ReadAllBytesAsync(filepath);
        }
    }
}
