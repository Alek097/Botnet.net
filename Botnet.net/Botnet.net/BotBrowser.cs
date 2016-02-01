using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading;
using System.Windows.Forms;

namespace Botnet.net
{
    public partial class BotBrowser : Form
    {
        bool _PageIsLoad = false;
        TimeSpan _time;
        public BotBrowser(BotLib.Task task)
        {
            InitializeComponent();

            this.Browser.Url = task.Uri;

            this._time = task.Time;

            this.Browser.DocumentCompleted += new
                 WebBrowserDocumentCompletedEventHandler(
                (sender, e) => 
                this._PageIsLoad = true);//когда документ загрузится поле _PageIsLoad примит истенное значение и запустит счётчик.

        }

        public void SleepToSession()// используется для задержки пока ссесия не закончится
        {
            while (!this._PageIsLoad) ;
            Thread.Sleep(_time);
        }
    }
}
