using System;
using System.Collections.Generic;

namespace invert_api.Models.Request
{
    public class TargetRequest
    {
       public List<string> Uids { get; set; }
       public long MessageId { get; set; }
    }
}
