using System;
using System.Collections.Generic;

namespace invert_api.Models.Response
{
    public class MessagesResponse
    {
        public MESSAGE Banner { get; set; }
        public MESSAGE Popup { get; set; }
        public MESSAGE Acknowledgment { get; set; }
        public List<MESSAGE> Marketing { get; set; }
    }
}
