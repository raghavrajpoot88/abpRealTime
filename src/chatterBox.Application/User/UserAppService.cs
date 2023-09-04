using AutoMapper;
using AutoMapper.Internal.Mappers;
using chatterBox.DTO;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace chatterBox.User
{
    [Authorize]
    public class UserAppService : CrudAppService<IdentityUser, UserDto, Guid, PagedAndSortedResultRequestDto>
    {


        public UserAppService(IRepository<IdentityUser, Guid> repository) : base(repository)
        {
        }
    }
}
