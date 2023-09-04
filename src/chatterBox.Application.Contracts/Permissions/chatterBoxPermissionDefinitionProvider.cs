using chatterBox.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace chatterBox.Permissions;

public class chatterBoxPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(chatterBoxPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(chatterBoxPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<chatterBoxResource>(name);
    }
}
