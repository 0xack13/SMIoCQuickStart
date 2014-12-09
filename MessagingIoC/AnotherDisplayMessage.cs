using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingIoC
{
    class AnotherDisplayMessage : IDisplayMessage
    {
        public string message()
        {
            return "Implementation message from another class! Hoooray!!";
        }
    }
}
