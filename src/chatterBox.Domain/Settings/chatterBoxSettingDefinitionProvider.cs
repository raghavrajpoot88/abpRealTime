using Volo.Abp.Settings;

namespace chatterBox.Settings;

public class chatterBoxSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(chatterBoxSettings.MySetting1));
    }
}
