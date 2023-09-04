using System;
using System.Collections.Generic;
using System.Text;
using chatterBox.Localization;
using Volo.Abp.Application.Services;

namespace chatterBox;

/* Inherit your application services from this class.
 */
public abstract class chatterBoxAppService : ApplicationService
{
    protected chatterBoxAppService()
    {
        LocalizationResource = typeof(chatterBoxResource);
    }
}
