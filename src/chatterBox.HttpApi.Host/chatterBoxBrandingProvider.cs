using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace chatterBox;

[Dependency(ReplaceServices = true)]
public class chatterBoxBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "chatterBox";
}
