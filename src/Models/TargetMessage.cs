using System;
namespace invert_api.Models
{
    public class TARGET_MESSAGE
    {
        public long Id { get; set; }
        public DateTime AcknowledgedDate { get; set; }
        public bool Acknowledged { get; set; }
        public string Uid { get; set; }
        public long MessageID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
