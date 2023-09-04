using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace chatterBox.Data;

/* This is used if database provider does't define
 * IchatterBoxDbSchemaMigrator implementation.
 */
public class NullchatterBoxDbSchemaMigrator : IchatterBoxDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
