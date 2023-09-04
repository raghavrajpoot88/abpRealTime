using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using chatterBox.Data;
using Volo.Abp.DependencyInjection;

namespace chatterBox.EntityFrameworkCore;

public class EntityFrameworkCorechatterBoxDbSchemaMigrator
    : IchatterBoxDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorechatterBoxDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the chatterBoxDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<chatterBoxDbContext>()
            .Database
            .MigrateAsync();
    }
}
