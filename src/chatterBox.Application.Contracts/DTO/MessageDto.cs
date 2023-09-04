using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace chatterBox.DTO
{
    public class MessageDto 
    {
            public Guid Id { get; set; }
            public Guid SenderId { get; set; } //Foreign Key
            public Guid ReceiverId { get; set; } //Foreign Key
            public string MsgBody { get; set; }
            public DateTime TimeStamp { get; set; }
        
    }
}
