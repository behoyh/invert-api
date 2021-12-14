using System;
namespace invert_api.Models
{
    public class LoginMessage
    {
        public alert alert { get; set; }
        public optionalUpdate optionalUpdate { get; set; }
        public requiredUpdate requiredUpdate { get; set; }
    }
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

    public class LOGIN_MESSAGE
    {
        public long Id { get; set; }
        public bool Active { get; set; }
        public string AndroidVersion { get; set; }
        public string AndroidMessage { get; set; }
        public string IosVersion { get; set; }
        public string IosMessage { get; set; }
        public LoginMessageType TYPE { get; set; }
        public bool Ios_Blocked { get; set; }
        public bool Android_Blocked { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public enum LoginMessageType
    {
        Blocked,
        RequiredUpdate,
        OptionalUpdate
    }
}
