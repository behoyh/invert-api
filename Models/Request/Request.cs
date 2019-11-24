using System;
namespace invert_api.Models.Request
{
    public class Request<T>
    {
        public string DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string OSVersion { get; set; }
        public string AppVersion { get; set; }
        public T Data { get; set; }
    }
}
