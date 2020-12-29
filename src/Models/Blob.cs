using System;
namespace invert_api.Models
{
    public class BLOB
    {
        public int ID { get; set; }
        public bool ACTIVE { get; set; }
        public string PATH { get; set; }
        public string NAME { get; set; }
        public BlobType BLOB_TYPE { get; set; }
        public DateTime CREATED { get; set; }
        public DateTime MODIFIED { get; set; }
    }
}
