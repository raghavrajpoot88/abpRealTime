using chatterBox.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace chatterBox.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(chatterBoxEntityFrameworkCoreModule),
    typeof(chatterBoxApplicationContractsModule)
    )]
public class chatterBoxDbMigratorModule : AbpModule
{
}
