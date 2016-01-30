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
            task = new Task(TaskType.Visit, "http://www.twitch.tv/kanalkarnaval", 1, 0, 0);
            return true;
        }
    }
}
