using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatterBox.ApiLogs
{
    public class LogDetails
    {
        public string Id { get; set; }
        public string? userName { get; set; }
        public string clientIpAddress { get; set; }
        public string parameter { get; set; }
        public DateTime creationTime { get; set; }
        
    }
}
