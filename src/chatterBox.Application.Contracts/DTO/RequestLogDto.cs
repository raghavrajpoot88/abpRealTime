using System;
using System.Collections.Generic;
using System.Text;

namespace chatterBox.DTO
{
    public class RequestLogDto
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string clientIpAddress { get; set; }    
        public string action { get; set; }
        public string parameter { get; set; }
        public string browserInfo { get; set; }
        public DateTime creationTime { get; set; }
    }
}
