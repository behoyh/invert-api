using System;
namespace invert_api.Models.Request
{
    public class PutBlobRequest
    {
        public byte[] Data { get; set; }
        public BlobType Type { get; set; }
    }
}
