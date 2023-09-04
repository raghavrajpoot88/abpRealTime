using System.Threading.Tasks;

namespace chatterBox.Data;

public interface IchatterBoxDbSchemaMigrator
{
    Task MigrateAsync();
}
