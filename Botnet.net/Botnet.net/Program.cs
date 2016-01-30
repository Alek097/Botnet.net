using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Botnet.net
{
    static class Program
    {
        public static int Count { get; internal set; }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            while (true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BotBrowser());
            }
        }
    }
}
