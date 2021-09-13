using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL
{
    public class TakenNameException: Exception
    {
        public TakenNameException(string message): base(message) { }
        public TakenNameException(){ }
    }
}
