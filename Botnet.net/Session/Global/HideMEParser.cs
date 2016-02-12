using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Session.Global
{
    class HideMEParser : IParser
    {
        private List<ProxyServer> _proxys;

        public HideMEParser()
        {
            
        }

        public List<ProxyServer> GetProxyServerList()
        {
            throw new NotImplementedException();
        }
    }
}
