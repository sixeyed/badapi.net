using System;

namespace Sixeyed.BadApi.Model
{
    public class ApiResponse
    {
        public DateTime Timestamp { get; set; }

        public string StatusCode { get; set; }

        public string Server { get; set; }
    }
}
