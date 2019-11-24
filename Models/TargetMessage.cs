using System;
namespace invert_api.Models
{
    public class TARGET_MESSAGE
    {
        public long ID { get; set; }
        public DateTime ACKNOWLEDGED_DATE { get; set; }
        public bool ACKNOWLEDGED { get; set; }
        public string UID { get; set; }
        public long MessageID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
