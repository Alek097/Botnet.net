using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Session.Global
{
    class HideMEParser : IParser
    {
        private List<ProxyServer> _proxys = new List<ProxyServer>();

        public HideMEParser()
        {
            UpdateList();
        }

        public List<ProxyServer> GetProxyServerList()
        {
            return this._proxys;
        }
        private void UpdateList()
        {
            string HTML;
            using (Page p = new Page(new Uri("http://hideme.ru/proxy-list/?maxtime=800&type=h")))
            {
                p.Show();
                HTML = p.GetPage();
                p.Close();
            }
        }
        private void SetList(string HTML)
        {
            string pattern = @"<tbody>[.\s]+?</tbody>";

            string tbody = Regex.Match(HTML, pattern, RegexOptions.IgnoreCase).ToString();
        }
    }
}
