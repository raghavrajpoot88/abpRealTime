using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace chatterBox.DTO
{
    public interface IUserAppService : ICrudAppService< //Defined Crud Method
        UserDto, //used to show the userlist
        Guid,  //primary key of the user entity
        PagedAndSortedResultRequestDto  //used for page sorting
        >
    {
    }


}
