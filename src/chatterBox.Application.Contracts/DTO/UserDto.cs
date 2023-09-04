using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace chatterBox.DTO
{
    public class UserDto:AuditedEntityDto<Guid>
    {
        public string email { get; set; }
        public string userName { get; set; }
    }
}
