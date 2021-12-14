using System;
namespace invert_api.Models
{
    public class BLOB
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public BlobType BlobType { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
