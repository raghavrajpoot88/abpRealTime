using System;
using System.Collections.Generic;
using System.Text;

namespace chatterBox.DTO
{
    public class CreateMessageDto
    {
        public Guid ReceiverId { get; set; }
        public string MsgBody { get; set; }
    }
}
