using System;

namespace BotLib
{
    public struct Task
    {
        public TaskType TaskType { get; private set; }
        public Uri Uri { get; private set; }
        public TimeSpan Time { get; private set; }

        internal Task(TaskType type, string url, TimeSpan time)
        {
            this.TaskType = type;
            this.Uri = new Uri(url);
            this.Time = time;
        }
    }
}
