﻿using System;
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
                    BotBrowser bot = new BotBrowser(task);
                    System.Threading.Tasks.Task closeApp = new System.Threading.Tasks.Task(() =>
                    {
                        bot.SleepToSession();
                        Application.Exit();
                    });
                    closeApp.Start();
                    Application.Run(bot);

                }
                Thread.Sleep(60 * 1000 * 5);//Задержка между сеансами 5 минут
            }
        }
    }
}
