using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace chatterBox.demo
{
    public class messageDemo : ApplicationService
    {
        public bool addMessage(string message)
        {
            if(message == null) return false;
            return true;
        }

        public bool AddMessage()
        {
            return true;
        }
    }
}
