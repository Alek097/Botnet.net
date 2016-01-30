using System;

namespace BotLib
{
    public struct Task
    {
        public TaskType TaskType { get; private set; }
        public Uri Uri { get; private set; }
        public TimeSpan Time { get; private set; }

        public Task(TaskType type, string url, int hours, int minutes, int seconds)
        {
            this.TaskType = type;
            this.Uri = new Uri(url);
            this.Time = new TimeSpan(hours, minutes, seconds);
        }
    }
}
