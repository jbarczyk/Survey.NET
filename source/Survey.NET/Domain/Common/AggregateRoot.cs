using System.Collections.Generic;
using Survey.NET.Common;

namespace Survey.NET.Domain.Common
{
    public abstract class AggregateRoot
    {
        private readonly List<Event> _changes = new List<Event>();

        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void ApplyChange(Event @event)
        {
            _changes.Add(@event);
        }
    }
}