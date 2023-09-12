using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace chatterBox.Messages
{
    public class MessageInfo
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(SenderId))]
        public Guid SenderId { get; set; } //Foreign Key
        [ForeignKey(nameof(ReceiverId))]
        public Guid ReceiverId { get; set; } //Foreign Key
        public string MsgBody { get; set; }
        public DateTime TimeStamp { get; set; }
        public IdentityUser? User { get; set; }
        public IdentityUser? Receiver {  get; set; }
    }
}
