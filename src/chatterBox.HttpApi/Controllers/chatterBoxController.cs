using chatterBox.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace chatterBox.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class chatterBoxController : AbpControllerBase
{
    protected chatterBoxController()
    {
        LocalizationResource = typeof(chatterBoxResource);
    }
}
