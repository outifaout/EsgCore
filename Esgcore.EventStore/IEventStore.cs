using System;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esgcore.EventStore
{
    public interface IEventStore
    {
        Task<EventStream> LoadStreamAsync(string streamId);

        Task<bool> AppendToStreamAsync(
            string streamId,
            int expectedVersion,
            IEnumerable<IEvent> events);
    }
}
