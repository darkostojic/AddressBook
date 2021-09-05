using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Responses
{
    public class CommonResponse
    {
        public int? ReturningId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
