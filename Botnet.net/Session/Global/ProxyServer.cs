using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session.Global
{
    struct ProxyServer
    {
        public string IP { get; set; }
        public string Port { get; set; }

        public override string ToString()
        {
            return IP + ":" + Port;
        }
    }
}
