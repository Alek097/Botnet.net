using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotLib
{
    public static class TaskManager
    {
        public static bool TryGetTask(out Task task)
        {
            task = new Task();

            TaskType type;
            string url;
            TimeSpan time;

            string[] taskers = GetTaskString().Split(';');//Я долго думал как назвать переменную и придумал таскеры, каждый элемент будет называться таскером. Если придумаю лучше исправлю.

            if (taskers.Length < 3)
                return false; // Если меньше трёх то формат строки уже не правильный, бот продолжит опрашивать сервак дальше пока не получит корректную строку.
            try
            {
                type = GetTaskType(taskers[0]);
                url = taskers[1];
                time = GetTime(taskers[2]);
            }
            catch (ArgumentException)
            {
                return false;
            }

            task = new Task(type, url, time);

            return true;
        }
        static TimeSpan GetTime(string time)
        {
            string[] times = time.Split(':');

            if (times.Length < 3)
                throw new ArgumentException(); // Время состоит из часов, минут, секунд. А значит три параметра.

            int hours;
            int minutes;
            int seconds;

            try
            {
                hours = int.Parse(times[0]);
                minutes = int.Parse(times[1]);
                seconds = int.Parse(times[2]);//Если формат не правильный выбрасываем исключение
            }
            catch (FormatException)
            {
                throw new ArgumentException();
            }

            return new TimeSpan(hours, minutes, seconds);
        }
        static TaskType GetTaskType(string type)
        {
            TaskType taskType = 0;

            switch (type)
            {
                case "visit":
                    {
                        taskType = TaskType.Visit;
                        break;
                    }
                //TODO: Дописать функции
                default:
                    {
                        throw new ArgumentException(); // Если нет совпадений выбрасываем исключение
                    }
            }

            return taskType;
        }
        static string GetTaskString()
        {
            return "visit;http://www.twitch.tv/kanalkarnaval;1:0:0";// TODO: Позже добавить обращение к серверу.
        }
    }
}
