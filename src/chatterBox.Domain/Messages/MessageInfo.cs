using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace chatterBox.Messages
{
    public class MessageInfo
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; } //Foreign Key
        public Guid ReceiverId { get; set; } //Foreign Key
        public string MsgBody { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
