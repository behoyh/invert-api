using System;
using System.Text.Json.Serialization;

namespace invert_api.Models
{
    public class MESSAGE
    {
        public long ID { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageType TYPE { get; set; }
        public bool ACTIVE { get; set; }
        public bool URGENT { get; set; }
        public bool ISTARGETED { get; set; }
        public string TITLE { get; set; }
        public string BODY { get; set; }
        public string LINK { get; set; }
        public long BLOB_ID { get; set; }
        public DateTime STARTDATE { get; set; }
        public DateTime ENDDATE { get; set; }
        public DateTime CREATED { get; set; }
        public DateTime MODIFIED { get; set; }
    }
}
