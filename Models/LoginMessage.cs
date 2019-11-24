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
}
