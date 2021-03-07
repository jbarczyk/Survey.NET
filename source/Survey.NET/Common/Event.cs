using System;

namespace Survey.NET.Common
{
    public abstract class Event
    {
        protected Event()
        {
            OccurredOn = DateTime.UtcNow;
        }

        public DateTime OccurredOn { get; }
    }
}