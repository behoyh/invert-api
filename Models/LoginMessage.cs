using System;
namespace invert_api.Models
{
    public class LoginMessage
    {
        public class alert
        {
            public string message { get; set; }
            public bool blocking { get; set; }
        }
        public class optionalUpdate
        {
            public string optionalVersion { get; set; }
            public string message { get; set; }
        }
        public class requiredUpdate
        {
            public string minimumVersion { get; set; }
            public string message { get; set; }
        }
    }

    public class LOGIN_MESSAGE
    {
        public long ID { get; set; }
        public bool ACTIVE { get; set; }
        public string ANDROID_VERSION { get; set; }
        public string ANDROID_MESSAGE { get; set; }
        public string IOS_VERSION { get; set; }
        public string IOS_MESSAGE { get; set; }
        public int TYPE { get; set; }
        public bool IOS_BLOCKED { get; set; }
        public bool ANDROID_BLOCKED { get; set; }
        public DateTime? STARTTIME { get; set; }
        public DateTime? ENDTIME { get; set; }
        public DateTime CREATED { get; set; }
        public DateTime MODIFIED { get; set; }
    }
}
