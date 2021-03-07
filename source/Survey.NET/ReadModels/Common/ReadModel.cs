using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Survey.NET.Common;

namespace Survey.NET.ReadModels.Common
{
    public abstract class ReadModel
    {
        public void Apply(IEnumerable<Event> events)
        {
            foreach (var @event in events.OrderBy(x => x.OccurredOn))
            {
                this.GetType()
                    .GetRuntimeMethods()
                    .First(x =>
                        x.Name.Equals("Apply") &&
                        x.GetParameters().FirstOrDefault()?.ParameterType == @event.GetType())
                    .Invoke(this, new object[] { @event });
            }
        }
    }
}
