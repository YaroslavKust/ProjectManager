using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.UI
{
    interface IMessenger
    {
        void SendMessage(string text);
        bool SendConfirmMessage(string text);
    }
}
