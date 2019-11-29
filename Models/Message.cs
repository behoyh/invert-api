using System;
namespace invert_api.Models
{
    public class MESSAGE
    {
        public long ID { get; set; }
        public MessageType TYPE { get; set; }
        public bool ACTIVE { get; set; }
        public bool URGENT { get; set; }
        public bool ISTARGETED { get; set; }
        public string TITLE { get; set; }
        public string BODY { get; set; }
        public string LINK { get; set; }
        public string IMAGE { get; set; }
        public DateTime STARTDATE { get; set; }
        public DateTime ENDDATE { get; set; }
        public DateTime CREATED { get; set; }
        public DateTime MODIFIED { get; set; }
    }
}
