using System;
using System.Text.Json.Serialization;

namespace invert_api.Models
{
    public class MESSAGE
    {
        public long Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageType Type { get; set; }
        public bool Active { get; set; }
        public bool Urgent { get; set; }
        public bool IsTargeted { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Link { get; set; }
        public long BlobId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
