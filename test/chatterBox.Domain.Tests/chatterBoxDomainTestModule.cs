using chatterBox.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace chatterBox;

[DependsOn(
    typeof(chatterBoxEntityFrameworkCoreTestModule)
    )]
public class chatterBoxDomainTestModule : AbpModule
{

}
