using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session.Global
{
    
    public partial class Page : Form
    {
        private bool _pageIsLoad;
        public Page(Uri url)
        {
            InitializeComponent();
            this.Browser.DocumentCompleted += new
                 WebBrowserDocumentCompletedEventHandler(
                (sender, e) =>
                this._pageIsLoad = true);
            this.Browser.Url = url;
        }
        public string GetPage()
        {
            while (!_pageIsLoad) ;
            return this.Browser.DocumentText;
        }
    }
}
