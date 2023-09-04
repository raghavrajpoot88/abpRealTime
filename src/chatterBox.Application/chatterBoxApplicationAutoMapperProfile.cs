using AutoMapper;
using chatterBox.DTO;
using chatterBox.Messages;

using Volo.Abp.Identity;

namespace chatterBox;

public class chatterBoxApplicationAutoMapperProfile : Profile
{
    public chatterBoxApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<IdentityUser, UserDto>();
        CreateMap<MessageInfo, MessageDto>();
        //CreateMap<IdentitySecurityLog, RequestLogDto>();
    }
}
