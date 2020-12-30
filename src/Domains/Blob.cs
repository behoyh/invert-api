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
                ACTIVE = true,
                PATH = filepath,
                NAME = name,
                BLOB_TYPE = type,
                CREATED = DateTime.Now,
                MODIFIED = DateTime.Now
            };

            return await _insertBlob.UploadBlobAsync(model);
        }

        public async Task<byte[]> GetBlob(long blob_id)
        {
            var result = await _getBlob.GetBlobAsync(blob_id);

            if (!result.Success)
            {
                return new byte[0];
            }

            var filepath = result.Data.PATH;

            return await File.ReadAllBytesAsync(filepath);
        }
    }
}
