using Volo.Abp.Modularity;

namespace chatterBox;

[DependsOn(
    typeof(chatterBoxApplicationModule),
    typeof(chatterBoxDomainTestModule)
    )]
public class chatterBoxApplicationTestModule : AbpModule
{

}
